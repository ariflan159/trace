using osu.Game.Rulesets.Trace.UI;
using osu.Game.Rulesets.Trace.UI.Effects;
using osuTK;

namespace osu.Game.Rulesets.Trace.Tests
{
    public partial class TestSceneTurbulenceKiai : TestSceneKiaiEffects<TurbulenceKiaiEffect, TurbulenceEmitter>
    {
        protected override void AddExtraSetupSteps()
        {
            AddStep("Add turbulence", () =>
            {
                KiaiContainer.Vortices.Add(new Vortex
                {
                    Position = new Vector2(0, -((TauPlayfield.BASE_SIZE.X / 2) + 105)),
                    Velocity = new Vector2(10),
                    Scale = 0.01f,
                    Speed = 5f,
                });
            });
        }
    }
}
