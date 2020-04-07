using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public class ActionRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public IActionScoringStrategy ScoringStrategy { get; set; }
        public HashSet<Guid> ConsiderationIds { get; set; }
    }
}