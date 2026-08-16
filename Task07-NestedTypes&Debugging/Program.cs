using Task07_NestedTypes_Debugging;

class Program
{
    static void Main(string[] args)
    {
        Company c1 = new Company();
        Company.Department d1= new Company.Department();
        d1.Printst(c1);
        // 2. Runtime Error:
        // Bug: Company c2 = null; d1.Prints(c2);
        Company c2 = new Company();
        d1.Printst(c2);
        // 3. Logical Error (Inside Department Class):
        // Bug: Console.WriteLine(co.mumber * 2);

    }
}
