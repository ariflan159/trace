using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests
{
    public abstract partial class TauModTestScene : ModTestScene
    {
        protected override Ruleset CreatePlayerRuleset() => new TauRuleset();
    }
}
