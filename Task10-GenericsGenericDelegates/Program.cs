using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {
        Repository<Employee> repo=new Repository<Employee>();
        repo.Add(new Employee(1, "abood"));
        repo.Add(new Employee(2, "zaid"));
        repo.Add(new Employee(3, "ali"));
        
        Console.WriteLine(repo.Find(x => x.Id==1));
        var filtered= repo.Filter(x => x.Id > 2);
        foreach (var item in filtered)
        {
            Console.WriteLine(item);
        }
         repo.ProcessAll(x => Console.WriteLine(x));

        Console.WriteLine("------------------------");
        var getAll=repo.GetAll();
        foreach (var item in getAll)
        {
            Console.WriteLine(item);
        }
        try
        {
            Console.WriteLine(repo.GetById(4));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("Remove");
        repo.Remove(repo.GetById(3));
        repo.ProcessAll(x => Console.WriteLine(x));

    }
}

public class Repository<T> where T : IEntity
{
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
    public void ProcessAll(Action<T> action) 
    {
        foreach (var i in item)
        {
            action(i);
        }
    }
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
    List <T> item = new List<T>();

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
    public T GetById(int id) {
        foreach (var i in item)
        {

            if (i.Id == id)
                return i;
        }
        throw new Exception("no id founded");
    }
}


public class Employee : IEntity
{
    public int Id { get;  set; }
    public string Name { get;  set; }

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