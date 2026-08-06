using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Localisation;
using osu.Game.Rulesets.Trace.Objects;
using osu.Game.Rulesets.Trace.UI;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Trace.Mods
{
    public class TauModTraceable : Mod, IApplicableToDrawableRuleset<TauHitObject>
    {
        public override string Name => "Traceable";
        public override string Acronym => "TC";
        public override ModType Type => ModType.Fun;
        public override LocalisableString Description => ModStrings.TraceableDescription;

        public void ApplyToDrawableRuleset(DrawableRuleset<TauHitObject> drawableRuleset)
        {
            if ((drawableRuleset as TauDrawableRuleset)?.Playfield is TauPlayfield playfield)
                playfield.PlayfieldPiece.Alpha = 0;
        }
    }
}
