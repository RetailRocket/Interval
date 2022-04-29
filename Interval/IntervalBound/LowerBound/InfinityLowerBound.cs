namespace Interval.IntervalBound.LowerBound
{
    using System.Collections.Generic;

    public class InfinityLowerBound<TPoint>
        : ILowerBound<TPoint>
        where TPoint : notnull
    {
        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return -1;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }

        public override bool Equals(
            object obj)
        {
            return obj is InfinityLowerBound<TPoint>;
        }

        public bool Equals(
            InfinityLowerBound<TPoint> other)
        {
            return other != null;
        }
    }
}