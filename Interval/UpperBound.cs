namespace Interval
{
    using System;
    using System.Collections.Generic;

    public readonly struct UpperBound<TPoint> :
        IComparable<UpperBound<TPoint>>,
        IComparable<TPoint>
    {
        private readonly bool isOpened;
        private readonly TPoint value;
        private readonly bool isInfinity;
        private readonly IComparer<TPoint> comparer;

        private UpperBound(
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

        public static UpperBound<TPoint> Opened(TPoint point)
        {
            return Opened(
                point: point,
                comparable: Comparer<TPoint>.Default);
        }

        public static UpperBound<TPoint> Opened(
            TPoint point,
            IComparer<TPoint> comparable)
        {
            return new UpperBound<TPoint>(
                isOpened: true,
                value: point,
                isInfinity: false,
                comparer: comparable);
        }

        public static UpperBound<TPoint> Closed(TPoint point)
        {
            return Closed(
                point: point,
                comparer: Comparer<TPoint>.Default);
        }

        public static UpperBound<TPoint> Closed(
            TPoint point,
            IComparer<TPoint> comparer)
        {
            return new UpperBound<TPoint>(
                isOpened: false,
                value: point,
                isInfinity: false,
                comparer: comparer);
        }

        public static UpperBound<TPoint> Infinity()
        {
            return new UpperBound<TPoint>(
                isOpened: true,
                value: default!,
                isInfinity: true,
                comparer: Comparer<TPoint>.Default);
        }

        public int CompareTo(
            UpperBound<TPoint> other)
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
                return 1;
            }

            if (!this.isOpened)
            {
                return this.comparer.Compare(this.value, other);
            }

            return this.comparer.Compare(this.value, other) == 1 ? 1 : -1;
        }
    }
}