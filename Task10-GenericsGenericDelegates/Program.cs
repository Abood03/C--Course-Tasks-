using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
        // Create repository and add employees
        Repository<Employee> repo = new Repository<Employee>();
        repo.Add(new Employee(1, "abood"));
        repo.Add(new Employee(2, "zaid"));
        repo.Add(new Employee(3, "ali"));

        // Find one employee using Predicate
        Console.WriteLine(repo.Find(x => x.Id == 1));

        // Filter employees using Func
        var filtered = repo.Filter(x => x.Id > 2);
        foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }

        // Apply an action to every employee
        repo.ProcessAll(x => Console.WriteLine(x));

        Console.WriteLine("------------------------");

        // Get all employees
        var getAll = repo.GetAll();
        foreach (var item in getAll)
        {
            Console.WriteLine(item);
        }

        // Handle an ID that does not exist
        try
        {
            Console.WriteLine(repo.GetById(4));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Remove an employee
        Console.WriteLine("Remove");
        repo.Remove(repo.GetById(3));
        repo.ProcessAll(x => Console.WriteLine(x));
    }
}

// Generic repository for any type that implements IEntity
public class Repository<T> where T : IEntity
{
    List<T> item = new List<T>();

    // Return items that match a condition
    public List<T> Filter(Func<T, bool> condition)
    {
        List<T> result = new List<T>();

        foreach (var i in item)
        {
            if (condition(i))
            {
                result.Add(i);
            }
        }

        return result;
    }

    // Run an action on every item
    public void ProcessAll(Action<T> action)
    {
        foreach (var i in item)
        {
            action(i);
        }
    }

    // Find the first item that matches the predicate
    public T Find(Predicate<T> predicate)
    {
        foreach (var i in item)
        {
            if (predicate(i))
            {
                return i;
            }
        }

        throw new Exception("Not Found");
    }

    public void Add(T entity)
    {
        item.Add(entity);
    }

    public void Remove(T entity)
    {
        item.Remove(entity);
    }

    public List<T> GetAll()
    {
        return item;
    }

    // Find an item by Id
    public T GetById(int id)
    {
        foreach (var i in item)
        {
            if (i.Id == id)
                return i;
        }

        throw new Exception("no id founded");
    }
}

// Employee implements IEntity so it can be used in Repository
public class Employee : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}