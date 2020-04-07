using System;

namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    [Serializable]
    public class LogisticResponseCurve : IResponseCurve
    {
        public LogisticResponseCurve(
            double slope,
            double exponent,
            double xShift,
            double yShift)
        {
            Slope = slope;
            Exponent = exponent;
            XShift = xShift;
            YShift = yShift;
        }

        public double Slope { get; }
        public double Exponent { get; }
        public double XShift { get; }
        public double YShift { get; }

        public double Evaluate(double input)
        {
            return Utils.Sanitize((Slope / (1 + Math.Exp(-10.0 * Exponent * (input - 0.5 - XShift)))) + YShift);
        }
    }
}