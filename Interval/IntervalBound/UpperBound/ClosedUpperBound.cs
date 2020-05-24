namespace Interval.IntervalBound.UpperBound
{
    using System.Collections.Generic;

    public class ClosedUpperBound<TPoint>
        : IUpperPointedBound<TPoint>
        where TPoint : notnull
    {
        public ClosedUpperBound(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public int CompareToPoint(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return comparer.Compare(this.Point, point);
        }

        public override int GetHashCode()
            => this.Point
                .GetHashCode();

        public override bool Equals(
            object? obj)
        {
            return obj is ClosedUpperBound<TPoint> key && this.Equals(key);
        }

        public bool Equals(
            ClosedUpperBound<TPoint> other)
        {
            return other != null && EqualityComparer<TPoint>.Default.Equals(this.Point, other.Point);
        }
    }
}