class Program
{
    static void Main(string[] args)
    {
        int number = default;
        double d = default;
        float f = default;
        decimal de = default;
        char ch = default;
        string s = default;
        bool b = default;
        byte by = default;
        long l = default;
        Console.WriteLine($"Default value of int: {number}");
        Console.WriteLine($"Default value of double: {d}");
        Console.WriteLine($"Default value of float: {f}");
        Console.WriteLine($"Default value of decimal: {de}");
        Console.WriteLine($"Default value of char: {ch}");
        Console.WriteLine($"Default value of string: {s}");
        Console.WriteLine($"Default value of bool: {b}");
        Console.WriteLine($"Default value of byte: {by}");
        Console.WriteLine($"Default value of long: {l}");
        Console.WriteLine("------------------------");
        Console.WriteLine($"int Max Value: {int.MaxValue}");
        Console.WriteLine($"int Min Value: {int.MinValue}");
        Console.WriteLine($"double Max Value: {double.MaxValue}");
        Console.WriteLine($"double Min Value: {double.MinValue}");
        Console.WriteLine($"float Max Value: {float.MaxValue}");
        Console.WriteLine($"float Min Value: {float.MinValue}");
        Console.WriteLine($"decimal Max Value: {decimal.MaxValue}");
        Console.WriteLine($"decimal Min Value: {decimal.MinValue}");
        Console.WriteLine($"char Max Value: {char.MaxValue}");
        Console.WriteLine($"char Min Value: {char.MinValue}");
        Console.WriteLine($"byte Max Value: {byte.MaxValue}");
        Console.WriteLine($"byte Min Value: {byte.MinValue}");
        Console.WriteLine($"long Max Value: {long.MaxValue}");
        Console.WriteLine($"long Min Value: {long.MinValue}");
    }
}