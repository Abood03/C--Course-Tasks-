using Capstone_LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    public class LibraryService : ISearchable<Book>
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public List<Book> Search(string query)
        {
            List<Book> results = new List<Book>();

            if (results.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }
            foreach (Book book in books)
            {
                if (book.Title.Contains(query, StringComparison.OrdinalIgnoreCase)||
                    book.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(book);
                }
                
            }

            return results;
        }
        private List<Member> members = new List<Member>();
        public void AddMember(Member member)
        {
            members.Add(member);
        }
    }
}
