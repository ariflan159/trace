using osu.Framework.Localisation;
using osu.Game.Rulesets.Trace.Localisation;

namespace osu.Game.Rulesets.Trace.Configuration
{
    public enum KiaiType
    {
        [LocalisableDescription(typeof(KiaiTypeStrings), nameof(KiaiTypeStrings.Turbulence))]
        Turbulence,

        [LocalisableDescription(typeof(KiaiTypeStrings), nameof(KiaiTypeStrings.Classic))]
        Classic,

        [LocalisableDescription(typeof(KiaiTypeStrings), nameof(KiaiTypeStrings.None))]
        None
    }
}
