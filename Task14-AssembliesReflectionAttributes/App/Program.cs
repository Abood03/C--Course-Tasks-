using Core;
using Services;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Employee e1=new Employee();
        e1.Id= 1;
        e1.Name = "abood Alabdi";
        EmployeeService es=new EmployeeService();
        es.EmployeeCreate(e1);
        
        var c=typeof(EmployeeService).Assembly;
        var q = c.GetTypes();
        foreach (var i in q)
        {
            if (i.IsDefined(typeof(AuditLogAttribute), false))
            {
                var classAttr = i.GetCustomAttribute<AuditLogAttribute>();

                if (classAttr != null)
                {
                    Console.WriteLine(i.Name);
                    Console.WriteLine(classAttr.description);
                }
            }

            var z = i.GetMethods();

            foreach (var m in z)
            {
                if (m.IsDefined(typeof(AuditLogAttribute), false))
                {
                    Console.WriteLine(m);

                    var f = m.GetCustomAttribute<AuditLogAttribute>();

                    if (f != null)
                        Console.WriteLine(f.description);
                }
            }
        }
    }
}