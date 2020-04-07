using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.ActionSetSelectionStrategies
{
    public class HighestScoringAction : IActionSetSelectionStrategy
    {
        public Action Select(DecisionMaker decisionMaker, IDictionary<Guid, IInputEvaluator> inputEvaluators)
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var actionSet in decisionMaker.ActionSets)
            {
                var pair = actionSet.Select(inputEvaluators);

                if (pair.Action != null && pair.Score >= maxScore)
                {
                    maxScore = pair.Score;
                    selectedAction = pair.Action;
                }
            }

            return selectedAction;
        }
    }
}