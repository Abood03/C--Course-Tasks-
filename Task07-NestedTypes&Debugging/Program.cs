class Program
{
    static void Main(string[] args)
    {
        Company c1 = new Company();
        Company.Department d1= new Company.Department();
        d1.Printst(c1);
        Company c2 = new Company();
        d1.Printst(c2);

    }
}
class Company
{
    private string s = "Company class";

    public class Department
    {
        public void Printst(Company co)
        {
            Console.WriteLine(co.s);
        }
    }
}