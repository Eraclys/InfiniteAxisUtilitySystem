using System;
using System.Collections.Generic;

namespace InfiniteAxisUtilitySystem
{
    public interface IActionSelectionStrategy
    {
        SelectedAction Select(ActionSet actionSet, IDictionary<Guid, IInputEvaluator> inputEvaluators);
    }
}