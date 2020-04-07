using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class DecisionMaker
    {
        readonly IList<ActionSet> _actionSets;

        public DecisionMaker(
            Guid id,
            IActionSetSelectionStrategy actionSetSelectionStrategy)
        {
            Id = id;
            ActionSetSelectionStrategy = actionSetSelectionStrategy;
            _actionSets = new List<ActionSet>();
        }

        public IEnumerable<ActionSet> ActionSets => _actionSets;

        public void AddActionSet(ActionSet actionSet)
        {
            if (_actionSets.Any(c => c.Id == actionSet.Id))
            {
                return;
            }

            _actionSets.Add(actionSet);
        }

        public void RemoveActionSet(Guid id)
        {
            var toRemove = _actionSets.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _actionSets.Remove(toRemove);
            }
        }

        public Guid Id { get; }
        public IActionSetSelectionStrategy ActionSetSelectionStrategy { get; }

        public Action Select(IDictionary<Guid, IInputEvaluator> inputEvaluators) =>
            ActionSetSelectionStrategy.Select(this, inputEvaluators);
    }
}