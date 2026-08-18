using System.Collections;

public class NumberRange:IEnumerable<int>
{
    public int start;
    public int end;

    public NumberRange(int start, int end)
    {
        this.start = start;
        this.end = end;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new NumberRangeEnumerator(start, end);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
public class NumberRangeEnumerator : IEnumerator<int>
{
    int Start;
    int End;
    int current;

    public NumberRangeEnumerator(int start, int end)
    {
        Start = start;
        End = end;
        current = start - 1;
    }

    public int Current => current;


    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        current++;
        if (current <= End)
            return true;
        else return false;
    }

    public void Reset()
    {
        current = Start - 1;
    }
}