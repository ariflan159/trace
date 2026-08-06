using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Mods;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests.Mods
{
    public partial class TestSceneHalfTime : TestSceneOsuPlayer
    {
        protected override TestPlayer CreatePlayer(Ruleset ruleset)
        {
            SelectedMods.Value = new Mod[] { new TauModAutoplay(), new TauModHalfTime() };

            return base.CreatePlayer(ruleset);
        }
    }
}
