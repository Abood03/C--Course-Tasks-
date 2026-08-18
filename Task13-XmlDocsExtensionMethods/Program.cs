
class Program
{
    static void Main(string[] args)
    {
        // ---------------- Repository ----------------

        Repository<Employee> repo = new Repository<Employee>();

        repo.Add(new Employee(1, "abood"));
        repo.Add(new Employee(2, "zaid"));
        repo.Add(new Employee(3, "ali"));

        Console.WriteLine("----- Get All -----");

        foreach (var employee in repo.GetAll())
        {
            Console.WriteLine(employee);
        }


        Console.WriteLine("\n----- Get By Id -----");

        Console.WriteLine(repo.GetById(2));


        Console.WriteLine("\n----- Filter -----");

        var filtered = repo.Filter(x => x.Id > 1);

        foreach (var employee in filtered)
        {
            Console.WriteLine(employee);
        }


        Console.WriteLine("\n----- Find -----");

        Console.WriteLine(
            repo.Find(x => x.Name == "abood")
        );


        Console.WriteLine("\n----- Process All -----");

        repo.ProcessAll(x =>
            Console.WriteLine($"Processing: {x.Name}")
        );


        // ---------------- Extension Methods ----------------

        Console.WriteLine("\n----- Extension Methods -----");

        string text = "hello world from c sharp";

        Console.WriteLine(text.ToTitleCase());

        Console.WriteLine(
            "This is a very long sentence".Truncate(10)
        );

        Console.WriteLine(
            "test@gmail.com".IsValidEmail()
        );

        Console.WriteLine(
            "Learning C# Extension Methods!".ToSlug()
        );
    }
}