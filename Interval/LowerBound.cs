namespace Interval
{
    using System;
    using System.Collections.Generic;

    public readonly struct LowerBound<TPoint> :
        IComparable<LowerBound<TPoint>>,
        IComparable<TPoint>
    {
        private LowerBound(
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

        private bool IsOpened { get; }

        private TPoint Value { get; }

        private bool IsInfinity { get; }

        private IComparer<TPoint> Comparer { get; }

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
                return -1;
            }

            if (!this.IsOpened)
            {
                return this.Comparer.Compare(this.Value, other);
            }

            return this.Comparer.Compare(this.Value, other) == -1 ? -1 : 1;
        }
    }
}