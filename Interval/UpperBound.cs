namespace Interval
{
    using System;
    using System.Collections.Generic;

    public readonly struct UpperBound<TPoint> :
        IComparable<UpperBound<TPoint>>,
        IComparable<TPoint>
    {
        private UpperBound(
            bool isOpened,
            TPoint value,
            bool isInfinity,
            IComparer<TPoint> comparer)
        {
            this.IsOpened = isOpened;
            this.Value = value;
            this.IsInfinity = isInfinity;
            this.Comparer = comparer;
        }

        public bool IsOpened { get; }

        public TPoint Value { get; }

        public bool IsInfinity { get; }

        private IComparer<TPoint> Comparer { get; }

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
            if (this.IsInfinity)
            {
                return other.IsInfinity ? 0 : -1;
            }

            return this.CompareTo(other.Value);
        }

        public int CompareTo(
            TPoint other)
        {
            if (this.IsInfinity)
            {
                return 1;
            }

            if (!this.IsOpened)
            {
                return this.Comparer.Compare(this.Value, other);
            }

            return this.Comparer.Compare(this.Value, other) == 1 ? 1 : -1;
        }
    }
}