using Core;

namespace Services
{
    [AuditLog("Employee Service")]
    public class EmployeeService
    {
        [AuditLog("Create Employee")]
        public void EmployeeCreate(Employee e)
        {
            Console.WriteLine(e.Id);
            Console.WriteLine(e.Name);
        }
    }
}