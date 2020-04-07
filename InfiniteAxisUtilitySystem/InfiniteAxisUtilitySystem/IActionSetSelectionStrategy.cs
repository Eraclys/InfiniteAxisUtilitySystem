using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public interface IActionSetSelectionStrategy
    {
        Action Select(DecisionMaker decisionMaker, IDictionary<Guid, IInputEvaluator> inputEvaluators);
    }
}