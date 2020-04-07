namespace InfiniteAxisUtilitySystem
{
    public interface IActionSetSelectionStrategy
    {
        Action Select(DecisionMaker decisionMaker, DecisionContext context);
    }
}