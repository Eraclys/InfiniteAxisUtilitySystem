using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public sealed class IntelligenceDatabase
    {
        public IList<IntelligenceDefinitionRecord> IntelligenceDefinitions { get; set; }
        public IList<DecisionMakerRecord> DecisionMakers { get; set; }
        public IList<ActionSetRecord> ActionSets { get; set; }
        public IList<ActionRecord> Actions { get; set; }
        public IList<ConsiderationRecord> Considerations { get; set; }
        public IList<InputRecord> Inputs { get; set; }
    }
}