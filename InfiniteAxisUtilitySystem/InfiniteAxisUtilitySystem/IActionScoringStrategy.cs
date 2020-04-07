namespace InfiniteAxisUtilitySystem
{
    public interface IActionScoringStrategy
    {
        double Score(Action action, DecisionContext context);
    }
}