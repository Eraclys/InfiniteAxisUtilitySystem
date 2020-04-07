using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.ActionScoringStrategies
{
    public class MultiplyConsiderationScores : IActionScoringStrategy
    {
        public double Score(Action action, IDictionary<Guid, IInputEvaluator> inputEvaluators)
        {
            var modificationFactor = 1.0 - 1.0 / action.Considerations.Count;
            var result = action.Weight;

            foreach (var consideration in action.Considerations)
            {
                var input = inputEvaluators[consideration.Input.Id].Evaluate();
                var score = consideration.ResponseCurve.Evaluate(input);
                var makeUpValue = (1.0 - score) * modificationFactor;
                score += makeUpValue * score;
                result *= score;
            }

            return result;
        }
    }
}