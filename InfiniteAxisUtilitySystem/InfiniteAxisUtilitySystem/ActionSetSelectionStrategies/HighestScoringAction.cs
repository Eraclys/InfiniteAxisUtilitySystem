using System;

namespace InfiniteAxisUtilitySystem.ActionSetSelectionStrategies
{
    [Serializable]
    public class HighestScoringAction : IActionSetSelectionStrategy
    {
        public Action Select(DecisionMaker decisionMaker, DecisionContext context)
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var actionSet in decisionMaker.ActionSets)
            {
                var pair = actionSet.Select(context);

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