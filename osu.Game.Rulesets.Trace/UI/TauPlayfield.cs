using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Pooling;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Trace.Mods;
using osu.Game.Rulesets.Trace.Objects;
using osu.Game.Rulesets.Trace.Objects.Drawables;
using osu.Game.Rulesets.Trace.Scoring;
using osu.Game.Rulesets.UI;
using osuTK;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Trace.UI
{
    [Cached]
    public partial class TauPlayfield : Playfield
    {
        private readonly JudgementContainer<DrawableTauJudgement> judgementLayer;
        private readonly Container judgementAboveHitObjectLayer;

        internal readonly EffectsContainer EffectsContainer;

        public static readonly Vector2 BASE_SIZE = new(768);
        public static readonly Bindable<Color4> ACCENT_COLOUR = new(Color4Extensions.FromHex(@"FF0040"));

        private readonly Dictionary<HitResult, DrawablePool<DrawableTauJudgement>> poolDictionary = new();

        public BindableBool ShouldShowPositionalEffects = new(true);

        // don't like this.
        protected override GameplayCursorContainer CreateCursor()
        {
            if (Mods != null && Mods.Any(m => m is TauModRoundabout))
                return new TauModRoundabout.RoundaboutTauCursor();

            return new TauCursor();
        }

        public new TauCursor Cursor => (TauCursor)base.Cursor;

        [Resolved]
        private TauCachedProperties tauCachedProperties { get; set; }

        public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

        public PlayfieldPiece PlayfieldPiece;

        public TauPlayfield()
        {
            RelativeSizeAxes = Axes.None;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            Size = BASE_SIZE;

            AddRangeInternal([
                PlayfieldPiece = new PlayfieldPiece(),
                judgementLayer = new JudgementContainer<DrawableTauJudgement> { RelativeSizeAxes = Axes.Both },
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Child = HitObjectContainer
                },
                EffectsContainer = new EffectsContainer(),
                judgementAboveHitObjectLayer = new Container { RelativeSizeAxes = Axes.Both }
            ]);

            NewResult += onNewResult;

            var hitWindows = new TauHitWindow();

            foreach (var result in Enum.GetValues(typeof(HitResult)).OfType<HitResult>().Where(r => r > HitResult.None && hitWindows.IsHitResultAllowed(r)))
                poolDictionary.Add(result, new DrawableJudgementPool(result, onJudgmentLoaded));

            AddRangeInternal(poolDictionary.Values);
        }

        [BackgroundDependencyLoader(true)]
        private void load([CanBeNull] IBeatmap beatmap)
        {
            RegisterPool<Beat, DrawableBeat>(10);
            RegisterPool<TraceBeat, DrawableTraceBeat>(10);
            RegisterPool<HardBeat, DrawableHardBeat>(5);
            RegisterPool<StrictHardBeat, DrawableStrictHardBeat>(5);

            RegisterPool<Slider, DrawableSlider>(5);
            RegisterPool<SliderHeadBeat, DrawableSliderHead>(5);
            RegisterPool<SliderHardBeat, DrawableSliderHardBeat>(5);
            RegisterPool<SliderRepeat, DrawableSliderRepeat>(5);
            RegisterPool<SliderTick, DrawableSliderTick>(10);

            if (beatmap != null)
                Cursor.SetAngleRange(beatmap.Difficulty.CircleSize);
        }

        private void onJudgmentLoaded(DrawableTauJudgement judgement)
        {
            judgementAboveHitObjectLayer.Add(judgement.ProxiedAboveHitObjectsContent);
        }

        private void onNewResult(DrawableHitObject judgedObject, JudgementResult result)
        {
            if (ShouldShowPositionalEffects.Value)
                EffectsContainer.OnNewResult(judgedObject, result);

            if (!judgedObject.DisplayResult || !DisplayJudgements.Value)
                return;

            judgementLayer.Add(poolDictionary[result.Type].Get(doj => doj.Apply(result, judgedObject)));
        }

        private partial class DrawableJudgementPool : DrawablePool<DrawableTauJudgement>
        {
            private readonly HitResult result;
            private readonly Action<DrawableTauJudgement> onLoaded;

            public DrawableJudgementPool(HitResult result, Action<DrawableTauJudgement> onLoaded)
                : base(10)
            {
                this.result = result;
                this.onLoaded = onLoaded;
            }

            protected override DrawableTauJudgement CreateNewDrawable()
            {
                var judgement = base.CreateNewDrawable();

                judgement.Apply(new JudgementResult(new HitObject(), new Judgement()) { Type = result }, null);

                onLoaded?.Invoke(judgement);

                return judgement;
            }
        }
        private double cumulativePaddleAngle = 0;
    private double lastFrameAbsoluteAngle = 0;
    private bool isFirstFrame = true;

    // PUBLIC STATE: The exact net delta traveled since the last hit object was judged
    public double RotationDeltaSinceLastNote { get; private set; }

    protected override void Update()
    {
        base.Update();

        // 1. Fetch the raw absolute angle of the paddle component this frame (usually 0 to 360)
        double currentAbsoluteAngle = Cursor.Rotation; 

        if (isFirstFrame)
        {
            lastFrameAbsoluteAngle = currentAbsoluteAngle;
            cumulativePaddleAngle = currentAbsoluteAngle;
            isFirstFrame = false;
            return;
        }

        // 2. Calculate the shortest delta between this frame and the last frame to detect wrap-arounds
        double frameDelta = currentAbsoluteAngle - lastFrameAbsoluteAngle;

        // Normalize the frame delta to (-180, 180] to handle 360 -> 0 degree crossings smoothly
        frameDelta = ((frameDelta + 180) % 360 + 360) % 360 - 180;

        // 3. Add the frame delta to our continuous running total
        cumulativePaddleAngle += frameDelta;
        
        // 4. Continually accumulate the movement into our note-to-note tracking window
        RotationDeltaSinceLastNote += frameDelta;

        // Save state for the next frame calculation
        lastFrameAbsoluteAngle = currentAbsoluteAngle;
    }

    /// <summary>
    /// Resets the note-to-note tracking window. Call this right after a note consumes the state.
    /// </summary>
    public void ResetNoteTrackingWindow()
    {
        RotationDeltaSinceLastNote = 0;
    }

    // CRITICAL: Reset everything if the player retries, rewinds, or restarts the map
    public void ResetAllState()
    {
        cumulativePaddleAngle = 0;
        lastFrameAbsoluteAngle = 0;
        isFirstFrame = true;
        RotationDeltaSinceLastNote = 0;
    }
    }
}
