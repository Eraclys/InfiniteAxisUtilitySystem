using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class Action
    {
        public Action(
            Guid id,
            string name,
            double weight,
            IActionScoringStrategy actionScoringStrategy,
            IReadOnlyCollection<Consideration> considerations)
        {
            Id = id;
            Name = name;
            Weight = weight;
            ActionScoringStrategy = actionScoringStrategy;
            Considerations = considerations;
        }

        public Guid Id { get; }
        public string Name { get; }
        public double Weight { get; }
        public IActionScoringStrategy ActionScoringStrategy { get; }
        public IReadOnlyCollection<Consideration> Considerations { get; }

        public double Score(DecisionContext context) =>
            ActionScoringStrategy.Score(this, context);
    }
}