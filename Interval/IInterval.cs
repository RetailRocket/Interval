namespace Interval
{
    using System.Collections.Generic;

    public interface IInterval<TPoint>
    {
        bool Contains(
            TPoint point,
            IComparer<TPoint> comparer);
    }
}