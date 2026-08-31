using Capstone_LibraryManagementSystem.Exceptions;
using Capstone_LibraryManagementSystem.Models;
using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        const string filePath = "libraryData.json";

        LibraryService library = new LibraryService();

        library.OnBookBorrowed += (book, member) =>
        {
            Console.WriteLine(
                $"EVENT: {member.Name} borrowed {book.Title}");
        };

        try
        {
            if (File.Exists(filePath))
            {
                await library.LoadDataAsync(filePath);
                Console.WriteLine("Data loaded successfully");
            }
            else
            {
                AddInitialData(library);
                Console.WriteLine("Initial data added");
            }

            library.BorrowBook(1, 1);
            library.ReturnBook(1, 1);

            await library.SaveDataAsync(filePath);

            Console.WriteLine("Data saved successfully");
        }
        catch (LibraryException ex)
        {
            Console.WriteLine($"Library error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"File error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void AddInitialData(LibraryService library)
    {
        library.AddBook(new Book(1, "C#", "Abood"));
        library.AddBook(new Book(2, "Java", "Ahmad"));
        library.AddBook(new Book(3, "C++", "Zaid"));

        Member member = new Member(1, "Abood");
        library.AddMember(member);
    }
}