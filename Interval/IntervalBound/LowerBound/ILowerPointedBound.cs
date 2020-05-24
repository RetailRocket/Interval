namespace Interval.IntervalBound.LowerBound
{
    public interface ILowerPointedBound<TPoint>
        : ILowerBound<TPoint>
        where TPoint : notnull
    {
        TPoint Point { get; }
    }
}