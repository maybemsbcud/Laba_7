namespace laba7;

public interface IMyList : IEnumerable<short>
{
    void AddToEnd(short value);
    void RemoveAt(int number);
    short? FindFirstMultiple(short divisor);
    void ReplaceEvenWithZero();
    IMyList FilterGreater(short threshold);
    void RemoveOddPositions();
}