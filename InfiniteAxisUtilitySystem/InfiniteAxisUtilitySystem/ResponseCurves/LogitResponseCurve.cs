using System;

namespace InfiniteAxisUtilitySystem.ResponseCurves
{
    [Serializable]
    public class LogitResponseCurve : IResponseCurve
    {
        public LogitResponseCurve(
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
            return Utils.Sanitize(Slope * Math.Log((input - XShift) / (1.0 - (input - XShift))) / 5.0 + 0.5 + YShift);
        }
    }
}