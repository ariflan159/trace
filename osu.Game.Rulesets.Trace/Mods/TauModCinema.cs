using System;
using System.Collections.Generic;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Objects;
using osu.Game.Rulesets.Trace.Replays;

namespace osu.Game.Rulesets.Trace.Mods
{
    public class TauModCinema : ModCinema<TauHitObject>
    {
        public override Type[] IncompatibleMods => base.IncompatibleMods.Concat(new[] { typeof(TauModAutopilot) }).ToArray();

        public override ModReplayData CreateReplayData(IBeatmap beatmap, IReadOnlyList<Mod> mods)
            => new(new TauAutoGenerator(beatmap, mods).Generate(), new ModCreatedUser { Username = "Astraeus" });
    }
}
