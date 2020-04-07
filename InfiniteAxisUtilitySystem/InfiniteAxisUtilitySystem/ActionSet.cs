using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class ActionSet
    {
        [JsonProperty(nameof(Actions))]
        readonly List<Action> _actions;

        public ActionSet(
            Guid id,
            string name,
            IActionSelectionStrategy actionSelectionStrategy)
        {
            Id = id;
            Name = name;
            ActionSelectionStrategy = actionSelectionStrategy;
            _actions = new List<Action>();
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public IActionSelectionStrategy ActionSelectionStrategy { get; private set; }

        [JsonIgnore]
        public IReadOnlyCollection<Action> Actions => _actions;

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

        public void Rename(string newName) => Name = newName;

        public void ChangeSelectionStrategy(IActionSelectionStrategy newStrategy) => ActionSelectionStrategy = newStrategy;

        public SelectedAction Select(DecisionContext context) =>
            ActionSelectionStrategy.Select(this, context);
    }
}