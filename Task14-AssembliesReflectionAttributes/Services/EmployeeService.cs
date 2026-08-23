using Core;

namespace Services
{
    // EmployeeService represents the service layer of the application.
    //
    // The Services assembly contains the business operations
    // related to employees.
    //
    // The AuditLog attribute is added to this class so that
    // Reflection can discover that this service should be audited.
    //
    // The description "Employee Service" can later be read
    // dynamically at runtime.
    [AuditLog("Employee Service")]
    public class EmployeeService
    {
        // Creates or processes an Employee object.
        //
        // The method receives an Employee from the Core assembly.
        //
        // AuditLog is applied to this method so Reflection
        // can detect the method and read its description.
        //
        // In this simple example, the method displays
        // the employee Id and Name.
        [AuditLog("Create Employee")]
        public void EmployeeCreate(Employee e)
        {
            Console.WriteLine(e.Id);
            Console.WriteLine(e.Name);
        }
    }
}