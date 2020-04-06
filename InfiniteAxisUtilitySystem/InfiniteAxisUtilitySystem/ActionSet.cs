using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class ActionSet
    {
        readonly IList<Action> _actions;

        public ActionSet(string id)
        {
            Id = id;
            _actions = new List<Action>();
        }

        public string Id { get; }

        public IEnumerable<Action> Actions => _actions;

        public void AddAction(Action action)
        {
            if (_actions.Any(c => c.Id == action.Id))
            {
                return;
            }

            _actions.Add(action);
        }

        public void RemoveAction(string id)
        {
            var toRemove = _actions.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _actions.Remove(toRemove);
            }
        }

        public (Action action, double score) Select()
        {
            var maxScore = .0;
            Action selectedAction = null;

            foreach (var action in _actions)
            {
                var score = action.Score();

                if (score >= maxScore)
                {
                    maxScore = score;
                    selectedAction = action;
                }
            }

            return (selectedAction, maxScore);
        }
    }
}