using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Utils;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Trace.Objects.Drawables.Pieces
{
    public partial class HardBeatPiece : CircularContainer
    {
        public HardBeatPiece()
        {
            Masking = true;
            BorderThickness = 15;
            BorderColour = Color4.White;
            RelativeSizeAxes = Axes.Both;
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            FillAspectRatio = 1;
            FillMode = FillMode.Fit;
            Colour = Color4.Purple;
            Child = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Alpha = 0,
                AlwaysPresent = true
            };

        }

    }
}
