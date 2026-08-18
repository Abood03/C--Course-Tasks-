using System.Collections;

class NumberRangeYield : IEnumerable<int>
{
    public int Start;
    public int End;

    public NumberRangeYield(int start, int end)
    {
        Start = start;
        End = end;
    }


    public IEnumerator<int> GetEnumerator()
    {
        for (int i = Start; i <= End; i++)
        {
            yield return i;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}