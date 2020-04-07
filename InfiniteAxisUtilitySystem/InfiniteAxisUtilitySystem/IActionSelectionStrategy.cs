namespace InfiniteAxisUtilitySystem
{
    public interface IActionSelectionStrategy
    {
        SelectedAction Select(ActionSet actionSet, DecisionContext context);
    }
}