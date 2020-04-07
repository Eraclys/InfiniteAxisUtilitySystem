using System;

namespace InfiniteAxisUtilitySystem
{
    public class Consideration
    {
        public Consideration(
            Guid id,
            Input input,
            IResponseCurve responseCurve)
        {
            Id = id;
            Input = input;
            ResponseCurve = responseCurve;
        }

        public Guid Id { get; }
        public Input Input { get; }
        public IResponseCurve ResponseCurve { get; }
    }
}