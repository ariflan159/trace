using System.Collections.Generic;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.Trace.Judgements;
using osu.Game.Scoring;
using osuTK;

namespace osu.Game.Rulesets.Trace.Scoring
{
    public partial class TauScoreProcessor : ScoreProcessor
    {
        public TauScoreProcessor(Ruleset ruleset)
            : base(ruleset)
        {
        }
        public override ScoreRank RankFromScore(double accuracy, IReadOnlyDictionary<HitResult, int> results)
        {
            ScoreRank rank = base.RankFromScore(accuracy, results);
            if (results.GetValueOrDefault(HitResult.Miss) > 0 && rank > ScoreRank.A) rank = ScoreRank.A;
            return rank;
        }
        protected override HitEvent CreateHitEvent(JudgementResult result)
            => base.CreateHitEvent(result).With(new Vector2((result as TauJudgementResult)?.DeltaAngle ?? 0, 0));

        protected override JudgementResult CreateResult(HitObject hitObject, Judgement judgement) => new TauJudgementResult(hitObject, judgement);
    }
}
