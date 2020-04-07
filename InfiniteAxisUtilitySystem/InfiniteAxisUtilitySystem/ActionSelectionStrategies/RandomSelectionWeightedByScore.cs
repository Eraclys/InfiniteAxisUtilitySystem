using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem.ActionSelectionStrategies
{
    public class RandomSelectionWeightedByScore : IActionSelectionStrategy
    {
        readonly Random _random;

        public RandomSelectionWeightedByScore(Random random)
        {
            _random = random;
        }

        public SelectedAction Select(ActionSet actionSet, IDictionary<Guid, IInputEvaluator> inputEvaluators)
        {
            var utilities = actionSet.Actions
                .Select(x => new SelectedAction(x, x.Score(inputEvaluators)))
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
                    return actionProbability.SelectedAction;
                }
            }

            return sortedListOfActionsByProbability[0].SelectedAction;
        }
    }
}