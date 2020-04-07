using System;

namespace InfiniteAxisUtilitySystem.Exceptions
{
    [Serializable]
    public class ItemNotFoundException<T> : Exception
    {
        public ItemNotFoundException(Guid id) : base($"{typeof(T).Name} with id '{id}' not found in database")
        {
        }
    }
}
