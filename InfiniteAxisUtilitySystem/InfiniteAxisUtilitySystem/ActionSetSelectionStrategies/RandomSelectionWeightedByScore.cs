﻿using System;
using System.Linq;

namespace InfiniteAxisUtilitySystem.ActionSetSelectionStrategies
{
    [Serializable]
    public class RandomSelectionWeightedByScore : IActionSetSelectionStrategy
    {
        public Action Select(DecisionMaker decisionMaker, DecisionContext context)
        {
            var utilities = decisionMaker.ActionSets
                .Select(x => x.Select(context))
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
                    return actionProbability.SelectedAction.Action;
                }
            }

            return sortedListOfActionsByProbability[0].SelectedAction.Action;
        }
    }
}