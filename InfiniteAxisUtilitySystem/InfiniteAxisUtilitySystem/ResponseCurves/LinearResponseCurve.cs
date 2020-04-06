namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    public abstract class LinearResponseCurve : IResponseCurve
    {
        public LinearResponseCurve(
            double slope,
            double xShift,
            double yShift)
        {
            Slope = slope;
            XShift = xShift;
            YShift = yShift;
        }

        public abstract string Id { get; }
        public double Slope { get; }
        public double XShift { get; }
        public double YShift { get; }

        public double Evaluate(double input)
        {
            return Utils.Sanitize((Slope * (input - XShift)) + YShift);
        }
    }
}