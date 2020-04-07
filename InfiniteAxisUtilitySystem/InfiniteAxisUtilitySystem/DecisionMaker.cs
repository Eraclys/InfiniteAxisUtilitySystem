using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public sealed class DecisionMaker
    {
        public DecisionMaker(
            Guid id,
            string name,
            IActionSetSelectionStrategy actionSetSelectionStrategy,
            IReadOnlyCollection<ActionSet> actionSets)
        {
            Id = id;
            Name = name;
            ActionSetSelectionStrategy = actionSetSelectionStrategy;
            ActionSets = actionSets;
        }

        public Guid Id { get; }
        public string Name { get; }
        public IActionSetSelectionStrategy ActionSetSelectionStrategy { get; }
        public IReadOnlyCollection<ActionSet> ActionSets { get; }

        public Action Select(DecisionContext context) =>
            ActionSetSelectionStrategy.Select(this, context);
    }
}