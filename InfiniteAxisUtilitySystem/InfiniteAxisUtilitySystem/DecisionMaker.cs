using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class DecisionMaker
    {
        [JsonProperty(nameof(ActionSets))]
        readonly List<ActionSet> _actionSets;

        public DecisionMaker(
            Guid id,
            string name,
            IActionSetSelectionStrategy actionSetSelectionStrategy)
        {
            Id = id;
            Name = name;
            ActionSetSelectionStrategy = actionSetSelectionStrategy;
            _actionSets = new List<ActionSet>();
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public IActionSetSelectionStrategy ActionSetSelectionStrategy { get; private set; }

        [JsonIgnore]
        public IReadOnlyCollection<ActionSet> ActionSets => _actionSets;

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

        public void Rename(string newName) => Name = newName;
        public void ChangeSelectionStrategy(IActionSetSelectionStrategy newStrategy) => ActionSetSelectionStrategy = newStrategy;

        public Action Select(DecisionContext context) =>
            ActionSetSelectionStrategy.Select(this, context);
    }
}