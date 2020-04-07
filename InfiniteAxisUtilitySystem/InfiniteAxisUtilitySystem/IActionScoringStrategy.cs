using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public interface IActionScoringStrategy
    {
        double Score(Action action, IDictionary<Guid, IInputEvaluator> inputEvaluators);
    }
}