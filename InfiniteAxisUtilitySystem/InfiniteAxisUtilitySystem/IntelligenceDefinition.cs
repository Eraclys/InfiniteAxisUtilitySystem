using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public sealed class IntelligenceDefinition
    {

        public IntelligenceDefinition(
            Guid id,
            string name,
            IReadOnlyCollection<DecisionMaker> decisionMakers)
        {
            Id = id;
            Name = name;
            DecisionMakers = decisionMakers;
        }

        public Guid Id { get; }
        public string Name { get; }
        public IReadOnlyCollection<DecisionMaker> DecisionMakers { get; }
    }
}