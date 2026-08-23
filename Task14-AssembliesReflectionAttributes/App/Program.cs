using Core;
using Services;
using System.Reflection;

class Program
{
    // Main is the entry point of the application.
    //
    // The App project connects the Core and Services assemblies.
    //
    // It creates an Employee object, sends it to EmployeeService,
    // and then demonstrates Reflection by scanning the Services
    // assembly for AuditLog attributes.
    static void Main(string[] args)
    {
        // Create a new Employee object from the Core assembly.
        Employee e1 = new Employee();

        // Assign values to the employee.
        e1.Id = 1;
        e1.Name = "abood Alabdi";


        // Create EmployeeService from the Services assembly.
        EmployeeService es = new EmployeeService();

        // Call the service method and pass the employee object.
        es.EmployeeCreate(e1);


        // Get the assembly that contains EmployeeService.
        //
        // typeof(EmployeeService) gives information about
        // the EmployeeService type.
        //
        // .Assembly gives us the assembly where that type exists.
        //
        // In this case, it gives us the Services assembly.
        var c = typeof(EmployeeService).Assembly;


        // Get all types/classes contained inside
        // the Services assembly.
        var q = c.GetTypes();


        // Loop through every type found in the assembly.
        foreach (var i in q)
        {
            // Check whether the current class contains
            // AuditLogAttribute.
            //
            // false means we do not search inherited attributes.
            if (i.IsDefined(typeof(AuditLogAttribute), false))
            {
                // Retrieve the actual AuditLogAttribute object
                // applied to the class.
                var classAttr =
                    i.GetCustomAttribute<AuditLogAttribute>();


                // Make sure the attribute was successfully found.
                if (classAttr != null)
                {
                    // Display the name of the class.
                    Console.WriteLine(i.Name);

                    // Display the description stored
                    // inside AuditLogAttribute.
                    Console.WriteLine(classAttr.description);
                }
            }


            // Get all methods that belong to
            // the current class.
            var z = i.GetMethods();


            // Loop through every method found in the class.
            foreach (var m in z)
            {
                // Check whether the current method
                // contains AuditLogAttribute.
                if (m.IsDefined(typeof(AuditLogAttribute), false))
                {
                    // Display information about the method.
                    Console.WriteLine(m);


                    // Retrieve the AuditLogAttribute object
                    // applied to the method.
                    var f =
                        m.GetCustomAttribute<AuditLogAttribute>();


                    // If the attribute exists,
                    // display its stored description.
                    if (f != null)
                    {
                        Console.WriteLine(f.description);
                    }
                }
            }
        }
    }
}