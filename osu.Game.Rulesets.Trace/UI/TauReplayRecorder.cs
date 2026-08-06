using System.Collections.Generic;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.Trace.Replays;
using osu.Game.Rulesets.UI;
using osu.Game.Scoring;
using osuTK;

namespace osu.Game.Rulesets.Trace.UI
{
    public partial class TauReplayRecorder : ReplayRecorder<TauAction>
    {
        public TauReplayRecorder(Score score)
            : base(score)
        {
        }

        protected override ReplayFrame HandleFrame(Vector2 mousePosition, List<TauAction> actions, ReplayFrame previousFrame)
            => new TauReplayFrame(Time.Current, mousePosition, actions.ToArray());
    }
}
