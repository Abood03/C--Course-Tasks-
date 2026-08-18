class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Ask the user to enter his name
            Console.WriteLine("Enter Your Name");
            var name = Console.ReadLine();

            // Ask the user to enter his age
            // The input is string because Console.ReadLine returns string
            Console.WriteLine("Enter Your Age");
            var input = Console.ReadLine();

            // Check if the name is empty
            // If it is empty, throw our custom ValidationException
            if (string.IsNullOrEmpty(name))
                throw new ValidationException("Name cannot be empty");

            int age;

            try
            {
                // Convert the age from string to int
                // Example:
                // "25" -> 25
                age = int.Parse(input);
            }
            catch (FormatException e)
            {
                // If the user enters something like "abc",
                // int.Parse throws FormatException

                // We catch the original exception
                // then wrap it inside our ValidationException
                // so the original error is stored in InnerException
                throw new ValidationException("Invalid age format", e);
            }

            // Check if the age is inside the allowed range
            // If not, throw a more specific exception
            if (age < 18 || age > 100)
                throw new InvalidAgeException("Age out of range");

            // If no exception happened,
            // registration is considered successful
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
        }

        // Catch InvalidAgeException first
        // because it is the most specific exception
        catch (InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }

        // Catch other validation problems
        // such as empty name or invalid age format
        catch (ValidationException e)
        {
            Console.WriteLine(e.Message);

            // InnerException contains the original exception
            // that caused our custom ValidationException
            if (e.InnerException != null)
            {
                Console.WriteLine(
                    $"Inner Exception: {e.InnerException.Message}"
                );
            }
        }

        // Catch any other custom application exception
        catch (AppException e)
        {
            Console.WriteLine(e.Message);
        }

        // Final general catch
        // This catches any unexpected exception
        // that was not handled above
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        // finally always executes
        // whether the registration succeeds or fails
        finally
        {
            Console.WriteLine("Registration process finished");
        }
    }
}


// Base custom exception for our application
// All application-specific exceptions can inherit from this class
public class AppException : Exception
{
    // Normal constructor that only receives an error message
    public AppException(string message)
        : base(message)
    {
    }

    // This constructor receives:
    // 1. Our custom error message
    // 2. The original exception that caused the problem
    //
    // The original exception will be stored in InnerException
    public AppException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}


// ValidationException represents errors
// related to validating user input
//
// It inherits from AppException
// so it is also considered an AppException
public class ValidationException : AppException
{
    // Constructor for normal validation errors
    public ValidationException(string message)
        : base(message)
    {
    }

    // Constructor used when a validation error
    // was caused by another exception
    public ValidationException(
        string message,
        Exception innerException
    )
        : base(message, innerException)
    {
    }
}


// InvalidAgeException is a more specific validation error
//
// It inherits from ValidationException because
// an invalid age is a type of validation problem
public class InvalidAgeException : ValidationException
{
    public InvalidAgeException(string message)
        : base(message)
    {
    }
}