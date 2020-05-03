namespace Interval
{
    using System;

    public readonly struct Interval<TPoint> :
        IComparable<Interval<TPoint>>
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

        public int CompareTo(
            Interval<TPoint> other)
        {
            var lowerBoundComparisonResult = this.LowerBound
                .CompareTo(other.LowerBound);
            if (lowerBoundComparisonResult != 0)
            {
                return lowerBoundComparisonResult;
            }

            return this.UpperBound.CompareTo(other.UpperBound);
        }
    }
}