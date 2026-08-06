namespace osu.Game.Rulesets.Trace.Objects
{
    public interface IHasOffsetAngle : IHasAngle
    {
        public float GetOffsetAngle();

        public float GetAbsoluteAngle() => (Angle + GetOffsetAngle()).Normalize();
    }
}
