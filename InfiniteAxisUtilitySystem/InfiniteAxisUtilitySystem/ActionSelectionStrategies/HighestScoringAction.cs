using System;

namespace InfiniteAxisUtilitySystem.ActionSelectionStrategies
{
    [Serializable]
    public class HighestScoringAction : IActionSelectionStrategy
    {
        public SelectedAction Select(ActionSet actionSet, DecisionContext context)
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var action in actionSet.Actions)
            {
                var score = action.Score(context);

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