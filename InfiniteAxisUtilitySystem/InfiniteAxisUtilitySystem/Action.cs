using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class Action
    {
        readonly IList<Consideration> _considerations;

        public Action(
            Guid id,
            double weight,
            IActionScoringStrategy actionScoringStrategy)
        {
            _considerations = new List<Consideration>();
            Id = id;
            Weight = weight;
            ActionScoringStrategy = actionScoringStrategy;
        }

        public Guid Id { get; }
        public double Weight { get; }
        public IActionScoringStrategy ActionScoringStrategy { get; }

        public IReadOnlyCollection<Consideration> Considerations => _considerations.ToList();

        public void AddConsideration(Consideration consideration)
        {
            if (_considerations.Any(c => c.Id == consideration.Id))
            {
                return;
            }

            _considerations.Add(consideration);
        }

        public void RemoveConsideration(Guid id)
        {
            var toRemove = _considerations.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _considerations.Remove(toRemove);
            }
        }

        public double Score(IDictionary<Guid, IInputEvaluator> inputEvaluators) =>
            ActionScoringStrategy.Score(this, inputEvaluators);
    }
}