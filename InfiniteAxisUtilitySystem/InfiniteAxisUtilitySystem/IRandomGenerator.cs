namespace InfiniteAxisUtilitySystem
{
    public interface IRandomGenerator
    {
        /// <summary>
        /// Provides a double between 0 and 1
        /// </summary>
        /// <returns></returns>
        double Next();
    }
}