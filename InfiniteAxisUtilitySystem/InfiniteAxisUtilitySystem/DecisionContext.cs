using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public class DecisionContext
    {
        public IRandomGenerator RandomGenerator { get; }
        readonly IDictionary<Guid, IInputEvaluator> _inputEvaluators;

        public DecisionContext(
            IDictionary<Guid, IInputEvaluator> inputEvaluators,
            IRandomGenerator randomGenerator)
        {
            RandomGenerator = randomGenerator;
            _inputEvaluators = inputEvaluators;
        }

        public IInputEvaluator Get(Input input)
        {
            return _inputEvaluators[input.Id];
        }
    }
}