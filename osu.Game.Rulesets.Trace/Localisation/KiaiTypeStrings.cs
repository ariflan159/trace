using osu.Framework.Localisation;

namespace osu.Game.Rulesets.Trace.Localisation
{
    public static class KiaiTypeStrings
    {
        private const string prefix = @"osu.Game.Rulesets.Trace.Localisation.Translations.KiaiType";

        /// <summary>
        /// "Turbulence"
        /// </summary>
        public static LocalisableString Turbulence => new TranslatableString(getKey(@"turbulence"), @"Turbulence");

        /// <summary>
        /// "Classic"
        /// </summary>
        public static LocalisableString Classic => new TranslatableString(getKey(@"classic"), @"Classic");

        /// <summary>
        /// "None"
        /// </summary>
        public static LocalisableString None => new TranslatableString(getKey(@"none"), @"None");

        private static string getKey(string key) => $@"{prefix}:{key}";
    }
}
