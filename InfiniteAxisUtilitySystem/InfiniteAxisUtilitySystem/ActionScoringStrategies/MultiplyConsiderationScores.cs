using System;

namespace InfiniteAxisUtilitySystem.ActionScoringStrategies
{
    [Serializable]
    public class MultiplyConsiderationScores : IActionScoringStrategy
    {
        public double Score(Action action, DecisionContext context)
        {
            var modificationFactor = 1.0 - 1.0 / action.Considerations.Count;
            var result = action.Weight;

            foreach (var consideration in action.Considerations)
            {
                var input = context.Get(consideration.Input).Evaluate();
                var score = consideration.ResponseCurve.Evaluate(input);
                var makeUpValue = (1.0 - score) * modificationFactor;
                score += makeUpValue * score;
                result *= score;
            }

            return result;
        }
    }
}