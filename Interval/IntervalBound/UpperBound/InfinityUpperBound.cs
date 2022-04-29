namespace Interval.IntervalBound.UpperBound
{
    using System.Collections.Generic;

    public class InfinityUpperBound<TPoint>
        : IUpperBound<TPoint>
        where TPoint : notnull
    {
        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return 1;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }

        public override bool Equals(
            object obj)
        {
            return obj is InfinityUpperBound<TPoint>;
        }

        public bool Equals(
            InfinityUpperBound<TPoint> other)
        {
            return other != null;
        }
    }
}