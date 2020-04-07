using System;
using System.Linq;

namespace InfiniteAxisUtilitySystem.ActionSelectionStrategies
{
    [Serializable]
    public class RandomSelectionWeightedByScore : IActionSelectionStrategy
    {
        public SelectedAction Select(ActionSet actionSet, DecisionContext context)
        {
            var utilities = actionSet.Actions
                .Select(x => new SelectedAction(x, x.Score(context)))
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
            var randomValue = context.RandomGenerator.Next();

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