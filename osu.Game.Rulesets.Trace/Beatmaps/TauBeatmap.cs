using System;
using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics.Sprites;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Trace.Localisation;
using osu.Game.Rulesets.Trace.Objects;
using osuTK;

namespace osu.Game.Rulesets.Trace.Beatmaps
{
    public class TauBeatmap : Beatmap<TauHitObject>
    {
        public override IEnumerable<BeatmapStatistic> GetStatistics()
        {
            int beats = HitObjects.Count(c => c is Beat);
            int traceBeats = HitObjects.Count(s => s is TraceBeat);
            int hardBeats = HitObjects.Count(hb => hb is HardBeat || hb is StrictHardBeat);

            float total = Math.Max(1, beats + traceBeats + hardBeats);

            return new[]
            {
                new BeatmapStatistic
                {
                    Name = BeatmapStrings.BeatCount,
                    Content = beats.ToString(),
                    CreateIcon = () => new SpriteIcon
                    {
                        Icon = FontAwesome.Solid.Square,
                        Scale = new Vector2(.7f)
                    },
                    BarDisplayLength = beats / total
                },
                new BeatmapStatistic
                {
                    Name = BeatmapStrings.TraceBeatCount,
                    Content = traceBeats.ToString(),
                    CreateIcon = () => new SpriteIcon
                    {
                        Icon = FontAwesome.Solid.MousePointer,
                        Scale = new Vector2(.7f),
                    },
                    BarDisplayLength = traceBeats / total
                },
                new BeatmapStatistic
                {
                    Name = BeatmapStrings.HardBeatCount,
                    Content = hardBeats.ToString(),
                    CreateIcon = () => new SpriteIcon
                    {
                        Icon = FontAwesome.Regular.Circle,
                        Scale = new Vector2(.7f)
                    },
                    BarDisplayLength = hardBeats / total
                }
            };
        }
    }
}
