using System;
using osu.Framework.Localisation;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Beatmaps;
using osu.Game.Rulesets.Trace.Localisation;

namespace osu.Game.Rulesets.Trace.Mods
{
    public class TauModStrict : Mod, IApplicableToBeatmapConverter
    {
        public override string Name => "Strict";
        public override LocalisableString Description => ModStrings.StrictDescription;
        public override string Acronym => "ST";
        public override ModType Type => ModType.DifficultyIncrease;
        public override Type[] IncompatibleMods => [typeof(TauModLenience), typeof(TauModLite)];

        public void ApplyToBeatmapConverter(IBeatmapConverter beatmapConverter)
        {
            if (beatmapConverter is not TauBeatmapConverter tauConverter)
                return;

            tauConverter.HardBeatsAreStrict = true;
        }
    }
}
