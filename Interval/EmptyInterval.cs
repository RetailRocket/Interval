namespace Interval
{
    using System.Collections.Generic;

    public class EmptyInterval<TPoint>
        : IInterval<TPoint>
    {
        public bool Contains(
            TPoint point,
            IComparer<TPoint> comparer) => false;

        public IInterval<TPoint> Intersect(
            IInterval<TPoint> other,
            IComparer<TPoint> comparer) => new EmptyInterval<TPoint>();
    }
}