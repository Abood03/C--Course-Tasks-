using System.Security.Principal;

class Program
{
    static void Main(string[] args)
    {

    }
}

public class Repository<T> where T : IEntity
{
    List<T> item = new List<T>();

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