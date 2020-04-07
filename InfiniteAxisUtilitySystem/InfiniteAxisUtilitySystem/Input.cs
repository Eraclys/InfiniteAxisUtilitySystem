using System;

namespace InfiniteAxisUtilitySystem
{
    [Serializable]
    public class Input
    {
        public Input(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
