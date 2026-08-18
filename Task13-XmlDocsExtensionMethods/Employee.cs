using Task13_XmlDocsExtensionMethods;

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