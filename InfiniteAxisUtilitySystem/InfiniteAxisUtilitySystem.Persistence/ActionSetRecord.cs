using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public class ActionSetRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IActionSelectionStrategy SelectionStrategy { get; set; }
        public HashSet<Guid> ActionIds { get; set; }
    }
}