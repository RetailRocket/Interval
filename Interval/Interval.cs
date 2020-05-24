namespace Interval
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;

    public class Interval<TPoint>
        : IInterval<TPoint>
        where TPoint : notnull
    {
        internal Interval(
            ILowerBound<TPoint> lowerBound,
            IUpperBound<TPoint> upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }

        public ILowerBound<TPoint> LowerBound { get; }

        public IUpperBound<TPoint> UpperBound { get; }

        public bool Contains(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return this.LowerBound.CompareToPoint(point, comparer) <= 0 &&
                   this.UpperBound.CompareToPoint(point, comparer) >= 0;
        }

        public override int GetHashCode()
            => HashCode.Combine(
                this.LowerBound.GetHashCode(),
                this.UpperBound.GetHashCode());

        public override bool Equals(
            object? obj)
        {
            return obj is Interval<TPoint> interval && this.Equals(interval);
        }

        public bool Equals(
            Interval<TPoint> other)
        {
            return other != null &&
                   this.LowerBound.Equals(other.LowerBound) &&
                   this.UpperBound.Equals(other.UpperBound);
        }
    }
}