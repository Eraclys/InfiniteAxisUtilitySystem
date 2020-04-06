using System;

namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    public abstract class NormalResponseCurve : IResponseCurve
    {
        public NormalResponseCurve(
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
            return Utils.Sanitize(Slope * Math.Exp(-30.0 * Exponent * (input - XShift - 0.5) * (input - XShift - 0.5)) + YShift);
        }
    }
}