namespace Interval
{
    using System;
    using System.Collections.Generic;

    public readonly struct LowerBound<TPoint> :
        IComparable<LowerBound<TPoint>>,
        IComparable<TPoint>
    {
        private readonly bool isOpened;
        private readonly TPoint value;
        private readonly bool isInfinity;
        private readonly IComparer<TPoint> comparer;

        private LowerBound(
            bool isOpened,
            TPoint value,
            bool isInfinity,
            IComparer<TPoint> comparer)
        {
            this.isOpened = isOpened;
            this.value = value;
            this.isInfinity = isInfinity;
            this.comparer = comparer;
        }

        public static LowerBound<TPoint> Opened(
            TPoint point)
        {
            return Opened(
                point: point,
                comparer: Comparer<TPoint>.Default);
        }

        public static LowerBound<TPoint> Opened(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return new LowerBound<TPoint>(
                isOpened: true,
                value: point,
                isInfinity: false,
                comparer: comparer);
        }

        public static LowerBound<TPoint> Closed(TPoint point)
        {
            return Closed(
                point: point,
                comparer: Comparer<TPoint>.Default);
        }

        public static LowerBound<TPoint> Closed(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return new LowerBound<TPoint>(
                isOpened: false,
                value: point,
                isInfinity: false,
                comparer: comparer);
        }

        public static LowerBound<TPoint> Infinity()
        {
            return new LowerBound<TPoint>(
                isOpened: true,
                value: default!,
                isInfinity: true,
                comparer: Comparer<TPoint>.Default);
        }

        public int CompareTo(
            LowerBound<TPoint> other)
        {
            if (this.isInfinity)
            {
                return other.isInfinity ? 0 : -1;
            }

            return this.CompareTo(other.value);
        }

        public int CompareTo(
            TPoint other)
        {
            if (this.isInfinity)
            {
                return -1;
            }

            if (!this.isOpened)
            {
                return this.comparer.Compare(this.value, other);
            }

            return this.comparer.Compare(this.value, other) == -1 ? -1 : 1;
        }
    }
}