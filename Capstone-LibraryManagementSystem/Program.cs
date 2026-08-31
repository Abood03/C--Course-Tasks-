using Capstone_LibraryManagementSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        LibraryService li=new LibraryService();
        li.AddBook(new Book(1, "C#", "abood"));
        li.AddBook(new Book(2, "Java", "ahmad"));
        li.AddBook(new Book(3, "C++", "zaid"));
        var results = li.Search("e");
        foreach (var item in results)
        {
            Console.WriteLine(item);
        }


    }
}