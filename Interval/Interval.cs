namespace Interval
{
    public readonly struct Interval<TPoint>
    {
        public Interval(
            LowerBound<TPoint> lowerBound,
            UpperBound<TPoint> upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public LowerBound<TPoint> LowerBound { get; }

        public UpperBound<TPoint> UpperBound { get; }
    }
}