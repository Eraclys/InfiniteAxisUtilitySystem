using System;

namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    public abstract class PolynomialResponseCurve : IResponseCurve
    {
        public PolynomialResponseCurve(
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

        public abstract string Id { get; }
        public double Slope { get; }
        public double Exponent { get; }
        public double XShift { get; }
        public double YShift { get; }

        public double Evaluate(double input)
        {
            return Utils.Sanitize((Slope * Math.Pow(input - XShift, Exponent)) + YShift);
        }
    }
}