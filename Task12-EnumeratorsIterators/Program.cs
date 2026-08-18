
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----Manual----");
        NumberRange n1=new NumberRange(8,15);
        foreach (var item in n1)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("----Yield----");
        NumberRangeYield n2=new NumberRangeYield(8,15);
        foreach (var item in n2)
        {
            Console.WriteLine(item);
        }
    }
}
