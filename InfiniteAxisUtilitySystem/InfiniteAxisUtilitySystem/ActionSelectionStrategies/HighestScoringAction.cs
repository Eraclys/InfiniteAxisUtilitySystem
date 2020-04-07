using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.ActionSelectionStrategies
{
    public class HighestScoringAction : IActionSelectionStrategy
    {
        public SelectedAction Select(ActionSet actionSet, IDictionary<Guid, IInputEvaluator> inputEvaluators)
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var action in actionSet.Actions)
            {
                var score = action.Score(inputEvaluators);

                if (score >= maxScore)
                {
                    maxScore = score;
                    selectedAction = action;
                }
            }

            return new SelectedAction(selectedAction, maxScore);
        }
    }
}