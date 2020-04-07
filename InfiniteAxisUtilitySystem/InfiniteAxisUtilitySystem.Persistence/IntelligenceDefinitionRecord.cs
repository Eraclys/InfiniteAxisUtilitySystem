using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public class IntelligenceDefinitionRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HashSet<Guid> DecisionMakerIds { get; set; }
    }
}