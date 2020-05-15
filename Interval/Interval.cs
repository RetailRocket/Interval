namespace Interval
{
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public class Interval<TPoint>
        : IInterval<TPoint>
    {
        public Interval(
            ILowerBound<TPoint> lowerBound,
            IUpperBound<TPoint> upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public ILowerBound<TPoint> LowerBound { get; }

        public IUpperBound<TPoint> UpperBound { get; }
    }
}