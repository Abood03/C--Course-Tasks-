class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee(1,"abood",1500);
        emp1[0] = "C#";
        Employee emp2 = new Employee(emp1);
        emp2[0] = "SQL";
        Console.WriteLine("Employee 1: " + emp1.ToString());
        Console.WriteLine("Skill 1: " + emp1[0]);
        Console.WriteLine("Employee 2 (Copy): " + emp2.ToString());
        Console.WriteLine("Skill 1: " + emp2[0]);

    }
}
class Employee
{
    private readonly int _id;
    private string _name;
    private double _salary;
    public double Salary {  get { return _salary; }
        set {
            if (value >= 0&&value<=maxSalary)
                _salary = value;
            else
                _salary = 0;
        }
            
    }
    const int maxSalary = 10000;

    public Employee(int id, string name, double salary)
    {
        _id = id;
        _name = name;
        Salary = salary;
    }

    public Employee()
    {

    }
    
    public Employee(Employee emp)
    {
        _id = emp._id;
        _name = emp._name;
        Salary = emp.Salary;
    }
    private string[] _skills = new string[3];
    public string this[int index]
    {
        get { return _skills[index]; }
        set { _skills[index] = value; }
    }
    public override string ToString()
    {
        return $"{{Id: {_id} , Name: {_name}, Salary: {Salary}}}";
    }
}