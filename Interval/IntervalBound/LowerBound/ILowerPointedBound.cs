namespace Interval.IntervalBound.LowerBound
{
    public interface ILowerPointedBound<TPoint>
        : ILowerBound<TPoint>
    {
        TPoint Point { get; }
    }
}