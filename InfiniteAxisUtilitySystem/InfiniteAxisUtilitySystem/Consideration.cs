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
        public string Name { get; private set; }
        public Input Input { get; private set; }
        public IResponseCurve ResponseCurve { get; private set; }

        public void Rename(string newName) => Name = newName;
        public void ChangeInput(Input newInput) => Input = newInput;
        public void ChangeResponseCurve(IResponseCurve newResponseCurve) => ResponseCurve = newResponseCurve;
    }
}