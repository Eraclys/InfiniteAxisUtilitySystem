using System;
using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem
{
    public class IntelligenceDefinition
    {
        readonly IList<DecisionMaker> _decisionMakers;

        public IntelligenceDefinition(
            Guid id)
        {
            Id = id;
            _decisionMakers = new List<DecisionMaker>();
        }

        public Guid Id { get; }

        public IEnumerable<DecisionMaker> DecisionMakers => _decisionMakers;


        public void AddDecisionMaker(DecisionMaker decisionMaker)
        {
            if (_decisionMakers.Any(c => c.Id == decisionMaker.Id))
            {
                return;
            }

            _decisionMakers.Add(decisionMaker);
        }

        public void RemoveDecisionMaker(Guid id)
        {
            var toRemove = _decisionMakers.FirstOrDefault(c => c.Id == id);

            if (toRemove != null)
            {
                _decisionMakers.Remove(toRemove);
            }
        }
    }
}