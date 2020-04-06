namespace InfiniteAxisUtilitySystem
{
    public static class Utils
    {
        public static double Sanitize(double value)
        {
            if (double.IsInfinity(value))
                return 0.0;

            if (double.IsNaN(value))
                return 0.0;

            if (value < 0.0)
                return 0.0;

            if (value > 1.0)
                return 1.0;

            return value;
        }
    }
}