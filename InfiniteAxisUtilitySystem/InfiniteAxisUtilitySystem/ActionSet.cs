using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class ActionSet
    {
        readonly IList<Action> _actions;

        public ActionSet(
            Guid id,
            IActionSelectionStrategy actionSelectionStrategy)
        {
            Id = id;
            ActionSelectionStrategy = actionSelectionStrategy;
            _actions = new List<Action>();
        }

        public Guid Id { get; }
        public IActionSelectionStrategy ActionSelectionStrategy { get; }

        public IEnumerable<Action> Actions => _actions;

        public void AddAction(Action action)
        {
            if (_actions.Any(c => c.Id == action.Id))
            {
                return;
            }

            _actions.Add(action);
        }

        public void RemoveAction(Guid id)
        {
            var toRemove = _actions.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _actions.Remove(toRemove);
            }
        }

        public SelectedAction Select(IDictionary<Guid, IInputEvaluator> inputEvaluators) =>
            ActionSelectionStrategy.Select(this, inputEvaluators);
    }
}