using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem.ActionSetSelectionStrategies
{
    public class RandomSelectionWeightedByScore : IActionSetSelectionStrategy
    {
        readonly Random _random;

        public RandomSelectionWeightedByScore(Random random)
        {
            _random = random;
        }

        public Action Select(DecisionMaker decisionMaker, IDictionary<Guid, IInputEvaluator> inputEvaluators)
        {
            var utilities = decisionMaker.ActionSets
                .Select(x => x.Select(inputEvaluators))
                .ToList();

            var utilitySum = utilities.Sum(x => x.Score);

            var sortedListOfActionsByProbability = utilities
                .Select(x => new
                {
                    Probability = x.Score / utilitySum,
                    SelectedAction = x
                })
                .OrderByDescending(x => x.Probability)
                .ToList();

            var runningSum = .0;
            var randomValue = _random.NextDouble();

            foreach (var actionProbability in sortedListOfActionsByProbability)
            {
                runningSum += actionProbability.Probability;

                if (runningSum >= randomValue)
                {
                    return actionProbability.SelectedAction.Action;
                }
            }

            return sortedListOfActionsByProbability[0].SelectedAction.Action;
        }
    }
}