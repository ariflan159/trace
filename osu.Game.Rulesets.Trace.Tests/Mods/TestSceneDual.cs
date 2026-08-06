using NUnit.Framework;
using osu.Game.Rulesets.Trace.Mods;
using osu.Game.Rulesets.Trace.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests.Mods
{
    public partial class TestSceneDual : TestSceneOsuPlayer
    {
        protected override TestPlayer CreatePlayer(Ruleset ruleset)
        {
            SelectedMods.Value = [new TauModAutoplay(), new TauModDual()];
            return base.CreatePlayer(ruleset);
        }

        protected override bool HasCustomSteps => true;

        private TauPlayfield playfield;
        private TauCursor cursor;

        [Test]
        public void TestTraceableMod()
        {
            CreateTest();

            AddStep("fetch playfield", () => { playfield = Player.DrawableRuleset.Playfield as TauPlayfield; });
            AddAssert("playfield is not null", () => playfield != null);
            AddStep("fetch cursor", () => cursor = playfield.Cursor);
            AddAssert("cursor amount is correct", () => cursor.Paddles.Count == 2);
        }
    }
}
