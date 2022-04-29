namespace Interval
{
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;

    public class EmptyInterval<TPoint>
        : IInterval<TPoint>
    {
        public bool Contains(
            TPoint point,
            IComparer<TPoint> comparer) => false;

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }

        public override bool Equals(
            object obj)
        {
            return obj is EmptyInterval<TPoint>;
        }

        public bool Equals(
            EmptyInterval<TPoint> other)
        {
            return other != null;
        }
    }
}