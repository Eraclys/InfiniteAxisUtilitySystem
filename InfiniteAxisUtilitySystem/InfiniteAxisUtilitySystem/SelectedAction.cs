namespace InfiniteAxisUtilitySystem
{
    public struct SelectedAction
    {
        public SelectedAction(Action action, double score)
        {
            Action = action;
            Score = score;
        }

        public Action Action { get; }
        public double Score { get; }
    }
}