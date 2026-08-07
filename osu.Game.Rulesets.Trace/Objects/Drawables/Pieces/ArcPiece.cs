using System;
using osu.Framework.Graphics.Lines;
using osuTK;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Trace.Objects.Drawables.Pieces
{
    public partial class ArcPiece : Path
    {
        public ArcPiece(Color4 color)
        {
            PathRadius = 8; 
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Colour = color;
            Vertices = generateArc(localRadius: 384, totalAngleWidth: 20);
        }

        private List<Vector2> generateArc(float localRadius, float totalAngleWidth)
        {
            var points = new List<Vector2>();
            
            float halfWidth = totalAngleWidth / 2f;
            float startAngle = -halfWidth;
            float endAngle = halfWidth;
            
            for (float theta = startAngle; theta <= endAngle; theta += 1)
            {
                float radians = theta * (MathF.PI / 180f); 
                
                float localX = MathF.Sin(radians) * localRadius;
                float localY = -MathF.Cos(radians) * localRadius;
                
                localY += localRadius;

                points.Add(new Vector2(localX, localY));
            }
            return points;
        }
    }
}
