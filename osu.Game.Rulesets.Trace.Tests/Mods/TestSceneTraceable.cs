using NUnit.Framework;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Mods;
using osu.Game.Rulesets.Trace.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests.Mods
{
    public partial class TestSceneTraceable : TestSceneOsuPlayer
    {
        protected override TestPlayer CreatePlayer(Ruleset ruleset)
        {
            SelectedMods.Value = new Mod[] { new TauModAutoplay(), new TauModTraceable() };
            return base.CreatePlayer(ruleset);
        }

        protected override bool HasCustomSteps => true;

        private TauPlayfield playfield;

        [Test]
        public void TestTraceableMod()
        {
            CreateTest();

            AddStep("fetch playfield", () => { playfield = Player.DrawableRuleset.Playfield as TauPlayfield; });
            AddAssert("playfield is invisible", () => playfield.PlayfieldPiece.Alpha == 0);
        }
    }
}
