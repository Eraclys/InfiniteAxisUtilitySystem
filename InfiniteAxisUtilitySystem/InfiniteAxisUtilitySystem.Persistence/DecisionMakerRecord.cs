using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public class DecisionMakerRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IActionSetSelectionStrategy SelectionStrategy { get; set; }
        public HashSet<Guid> ActionSetIds { get; set; }
    }
}