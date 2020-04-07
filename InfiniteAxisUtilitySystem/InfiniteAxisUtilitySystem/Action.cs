using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class Action
    {
        readonly IList<Consideration> _considerations;

        public Action(
            Guid id,
            string name,
            double weight,
            IActionScoringStrategy actionScoringStrategy)
        {
            _considerations = new List<Consideration>();
            Id = id;
            Name = name;
            Weight = weight;
            ActionScoringStrategy = actionScoringStrategy;
        }

        public Guid Id { get; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public IActionScoringStrategy ActionScoringStrategy { get; private set; }

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

        public void ChangeWeight(double newWeight) => Weight = newWeight;

        public void ScoringStrategy(IActionScoringStrategy newStrategy) => ActionScoringStrategy = newStrategy;

        public void Rename(string newName) => Name = newName;

        public double Score(DecisionContext context) =>
            ActionScoringStrategy.Score(this, context);
    }
}