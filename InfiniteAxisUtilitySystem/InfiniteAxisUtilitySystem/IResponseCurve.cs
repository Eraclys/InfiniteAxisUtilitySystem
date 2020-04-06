namespace InfiniteAxisUtilitySystem
{
    public interface IResponseCurve
    {
        string Id { get; }
        double Evaluate(double input);
    }
}