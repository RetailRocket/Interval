namespace Interval.IntervalBound
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;

    public class LowerBoundComparer<TPoint>
        : IComparer<ILowerBound<TPoint>>
    {
        private readonly IComparer<TPoint> comparer;

        public LowerBoundComparer(
            IComparer<TPoint> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(
            ILowerBound<TPoint> left,
            ILowerBound<TPoint> right)
        {
            switch (left)
            {
                case InfinityLowerBound<TPoint> _ when right is InfinityLowerBound<TPoint>:
                    return 0;
                case InfinityLowerBound<TPoint> _ when right is ILowerPointedBound<TPoint>:
                    return -1;
                case ILowerPointedBound<TPoint> _ when right is InfinityLowerBound<TPoint>:
                    return 1;
            }

            var leftPointedBorder = (ILowerPointedBound<TPoint>)left;
            var rightPointedBorder = (ILowerPointedBound<TPoint>)right;

            var resultOfComparisonsPointedBorders = this.comparer
                .Compare(
                    x: leftPointedBorder.Point,
                    y: rightPointedBorder.Point);

            if (resultOfComparisonsPointedBorders != 0)
            {
                return resultOfComparisonsPointedBorders;
            }

            switch (left)
            {
                case OpenLowerBound<TPoint> _ when right is OpenLowerBound<TPoint>:
                case ClosedLowerBound<TPoint> _ when right is ClosedLowerBound<TPoint>:
                    return 0;
                case ClosedLowerBound<TPoint> _ when right is OpenLowerBound<TPoint>:
                    return -1;
                case OpenLowerBound<TPoint> _ when right is ClosedLowerBound<TPoint>:
                    return 1;
            }

            throw new AggregateException(string.Empty);
        }
    }
}