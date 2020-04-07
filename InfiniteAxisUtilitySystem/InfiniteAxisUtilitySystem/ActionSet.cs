using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class ActionSet
    {
        public ActionSet(
            Guid id,
            string name,
            IActionSelectionStrategy actionSelectionStrategy,
            IReadOnlyCollection<Action> actions)
        {
            Id = id;
            Name = name;
            ActionSelectionStrategy = actionSelectionStrategy;
            Actions = actions;
        }

        public Guid Id { get; }
        public string Name { get; }
        public IActionSelectionStrategy ActionSelectionStrategy { get; }
        public IReadOnlyCollection<Action> Actions { get; }

        public SelectedAction Select(DecisionContext context) =>
            ActionSelectionStrategy.Select(this, context);
    }
}