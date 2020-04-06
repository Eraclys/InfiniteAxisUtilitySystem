namespace InfiniteAxisUtilitySystem
{
    public class Consideration
    {
        public Consideration(
            string id,
            IInput input,
            IResponseCurve responseCurve)
        {
            Id = id;
            Input = input;
            ResponseCurve = responseCurve;
        }

        public string Id { get; }
        public IInput Input { get; }
        public IResponseCurve ResponseCurve { get; }

        public double Score() => ResponseCurve.Evaluate(Input.Evaluate());
    }
}