using osu.Framework.Localisation;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Trace.Localisation;

namespace osu.Game.Rulesets.Trace.Mods
{
    public class TauModEasy : ModEasyWithExtraLives
    {
        public override LocalisableString Description => ModStrings.EasyDescription;
    }
}
