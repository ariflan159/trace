using NUnit.Framework;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests
{
    [TestFixture]
    public partial class TestSceneOsuPlayer : PlayerTestScene
    {
        protected override Ruleset CreatePlayerRuleset() => new TauRuleset();
    }
}
