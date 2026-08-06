namespace osu.Game.Rulesets.Trace.Objects
{
    public class SliderHeadBeat : Beat, IHasOffsetAngle
    {
        public Slider ParentSlider { get; set; }

        public float GetOffsetAngle() => ParentSlider.Angle;
    }
}
