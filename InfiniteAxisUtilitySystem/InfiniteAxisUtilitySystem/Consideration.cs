using System;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class Consideration
    {
        public Consideration(
            Guid id,
            string name,
            Input input,
            IResponseCurve responseCurve)
        {
            Id = id;
            Name = name;
            Input = input;
            ResponseCurve = responseCurve;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Input Input { get; }
        public IResponseCurve ResponseCurve { get; }
    }
}