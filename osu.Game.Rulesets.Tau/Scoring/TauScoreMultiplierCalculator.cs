using JetBrains.Annotations;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Tau.Mods;

namespace osu.Game.Rulesets.Tau.Scoring;

// Based off of OsuScoreMultiplierCalculatorV1 for now, and for simplicity
public class TauScoreMultiplierCalculator : ScoreMultiplierCalculator
{
    public TauScoreMultiplierCalculator([NotNull] ScoreMultiplierContext context)
        : base(context)
    {

        #region Difficulty Reduction

        Single<TauModEasy>(0.5);
        Single<TauModNoFail>(0.5);
        Single<TauModHalfTime>(ht => rateAdjustMultiplier(ht.SpeedChange.Value));
        Single<TauModDaycore>(dc => rateAdjustMultiplier(dc.SpeedChange.Value));
        Single<TauModLenience>(0.6);

        #endregion

        #region Difficulty Increase

        Single<TauModHardRock>(hr => hr.UsesDefaultConfiguration ? 1.06 : 1);
        // Sudden Death
        // Perfect
        Single<TauModDoubleTime>(dt => rateAdjustMultiplier(dt.SpeedChange.Value));
        Single<TauModNightcore>(nc => rateAdjustMultiplier(nc.SpeedChange.Value));
        Single<TauModFadeOut>(fo => fo.UsesDefaultConfiguration ? 1.06 : 1);
        Single<TauModFadeIn>(fi => fi.UsesDefaultConfiguration ? 1.06 : 1);
        Single<TauModFlashlight>(fl => fl.UsesDefaultConfiguration ? 1.12 : 1);
        Single<TauModStrict>(st => st.UsesDefaultConfiguration ? 1.12 : 1);

        #endregion

        #region Conversion

        Single<TauModDifficultyAdjust>(0.5);
        Single<TauModLite>(0.5);

        #endregion

        #region Fun

        Single<ModWindUp>(0.5);
        Single<ModWindDown>(0.5);
        Single<ModAdaptiveSpeed>(0.5);
        // Impossible sliders
        // Roundabout
        // No scope
        // Traceable
        // Dual
        // Barrel roll

        #endregion

    }

    private static double rateAdjustMultiplier(double speedChange)
    {
        // Round to the nearest multiple of 0.1.
        double value = (int)(speedChange * 10) / 10.0;

        // Offset back to 0.
        value -= 1;

        if (speedChange >= 1)
            return 1 + value / 5;

        return 0.6 + value;
    }
}
