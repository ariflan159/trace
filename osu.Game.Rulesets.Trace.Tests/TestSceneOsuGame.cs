using osu.Framework.Allocation;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.Trace.Tests
{
    public partial class TestSceneOsuGame : OsuTestScene
    {
        [BackgroundDependencyLoader]
        private void load()
        {
            AddGame(new OsuGame());
        }
    }
}
