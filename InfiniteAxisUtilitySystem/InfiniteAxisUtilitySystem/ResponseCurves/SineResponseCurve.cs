using System;

namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    [Serializable]
    public class SineResponseCurve : IResponseCurve
    {
        public SineResponseCurve(
            double slope,
            double xShift,
            double yShift)
        {
            Slope = slope;
            XShift = xShift;
            YShift = yShift;
        }

        public double Slope { get; }
        public double XShift { get; }
        public double YShift { get; }

        public double Evaluate(double input)
        {
            return Utils.Sanitize(0.5 * Slope * Math.Sin(2.0 * Math.PI * (input - XShift)) + 0.5 + YShift);
        }
    }
}