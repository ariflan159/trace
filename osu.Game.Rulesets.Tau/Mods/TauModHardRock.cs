using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Tau.Objects;

namespace osu.Game.Rulesets.Tau.Mods
{
    public class TauModHardRock : ModHardRock, IApplicableToHitObject
    {
        public void ApplyToHitObject(HitObject hitObject)
        {
            if (hitObject is not IHasAngle angledHitObject)
                return;

            float newAngle = angledHitObject.Angle;
            newAngle -= 180;
            newAngle.NormalizeAngle();

            angledHitObject.Angle = newAngle;
        }
    }
}
