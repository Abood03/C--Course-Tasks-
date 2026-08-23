namespace Core
{
    // Represents the Employee model used in the application.
    //
    // This class is stored inside the Core assembly because Core
    // contains the basic models and shared components of the system.
    //
    // Both the Services project and the App project can use this class.
    //
    // The Employee object contains the basic information needed
    // to represent an employee in the system.
    public class Employee
    {
        // Unique identifier for the employee.
        public int Id { get; set; }

        // Stores the employee's name.
        public string Name { get; set; }
    }
}