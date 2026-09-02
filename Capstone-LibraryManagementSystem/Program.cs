using Capstone_LibraryManagementSystem.Exceptions;
using Capstone_LibraryManagementSystem.Models;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

/// <summary>
/// Provides the console entry point and user interface for the library system.
/// </summary>
class Program
{
    /// <summary>
    /// Runs the interactive library menu.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>A task representing the application lifetime.</returns>
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

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Library Menu ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Member");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Borrow Book");
                Console.WriteLine("5. Return Book");
                Console.WriteLine("6. Show Audit Methods");
                Console.WriteLine("0. Save and Exit");
                Console.Write("Choose: ");

                string? choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Book ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int bookId))
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Title: ");
                            string? title = Console.ReadLine();

                            Console.Write("Author: ");
                            string? author = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(title) ||
                                string.IsNullOrWhiteSpace(author))
                            {
                                Console.WriteLine("Title and author are required");
                                break;
                            }

                            library.AddBook(new Book(bookId, title, author));

                            Console.WriteLine("Book added successfully");
                            break;

                        case "2":
                            Console.Write("Member ID: ");

                            if (!int.TryParse(Console.ReadLine(), out int memberId))
                            {
                                Console.WriteLine("Invalid ID");
                                break;
                            }

                            Console.Write("Member name: ");
                            string? memberName = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(memberName))
                            {
                                Console.WriteLine("Member name is required");
                                break;
                            }

                            library.AddMember(
                                new Member(memberId, memberName));

                            Console.WriteLine("Member added successfully");
                            break;

                        case "3":
                            Console.Write("Enter title or author: ");
                            string? query = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(query))
                            {
                                Console.WriteLine("Search text is required");
                                break;
                            }

                            List<Book> results = library.Search(query);

                            if (results.Count == 0)
                            {
                                Console.WriteLine("No books found");
                                break;
                            }

                            foreach (Book book in results)
                            {
                                Console.WriteLine(book);
                            }

                            break;


                        case "4":
                            Console.Write("Book ID: ");

                            if (!int.TryParse(
                                    Console.ReadLine(),
                                    out int borrowBookId))
                            {
                                Console.WriteLine("Invalid book ID");
                                break;
                            }

                            Console.Write("Member ID: ");

                            if (!int.TryParse(
                                    Console.ReadLine(),
                                    out int borrowerId))
                            {
                                Console.WriteLine("Invalid member ID");
                                break;
                            }

                            library.BorrowBook(borrowBookId, borrowerId);
                            break;

                        case "5":
                            Console.Write("Book ID: ");

                            if (!int.TryParse(
                                    Console.ReadLine(),
                                    out int returnBookId))
                            {
                                Console.WriteLine("Invalid book ID");
                                break;
                            }

                            Console.Write("Member ID: ");

                            if (!int.TryParse(
                                    Console.ReadLine(),
                                    out int returningMemberId))
                            {
                                Console.WriteLine("Invalid member ID");
                                break;
                            }

                            library.ReturnBook(
                                returnBookId,
                                returningMemberId);

                            break;

                        case "6":
                            ShowAuditMethods();
                            break;

                        case "0":
                            await library.SaveDataAsync(filePath);
                            Console.WriteLine("Data saved successfully");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (LibraryException ex)
                {
                    Console.WriteLine(
                        $"Library error: {ex.Message}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(
                        $"File error: {ex.Message}");
                }
                
            }
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

    /// <summary>
    /// Adds sample books and a member when no saved data exists.
    /// </summary>
    /// <param name="library">The library service to initialize.</param>
    static void AddInitialData(LibraryService library)
    {
        library.AddBook(new Book(1, "C#", "Abood"));
        library.AddBook(new Book(2, "Java", "Ahmad"));
        library.AddBook(new Book(3, "C++", "Zaid"));

        Member member = new Member(1, "Abood");
        library.AddMember(member);
    }
    /// <summary>
    /// Displays operations decorated with the audit log attribute.
    /// </summary>
    static void ShowAuditMethods()
    {
        Type serviceType = typeof(LibraryService);

        MethodInfo[] methods = serviceType.GetMethods();

        foreach (MethodInfo method in methods)
        {
            AuditLogAttribute? audit =
                method.GetCustomAttribute<AuditLogAttribute>();

            if (audit != null)
            {
                Console.WriteLine(
                    $"{method.Name}: {audit.Description}");
            }
        }
    }
}