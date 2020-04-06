using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class DecisionMaker
    {
        readonly IList<ActionSet> _actionSets;

        public DecisionMaker(
            string id)
        {
            Id = id;
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

        public void RemoveActionSet(string id)
        {
            var toRemove = _actionSets.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _actionSets.Remove(toRemove);
            }
        }

        public string Id { get; }

        public Action Select()
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var actionSet in _actionSets)
            {
                var pair = actionSet.Select();

                if (pair.action != null && pair.score >= maxScore)
                {
                    maxScore = pair.score;
                    selectedAction = pair.action;
                }
            }

            return selectedAction;
        }
    }
}