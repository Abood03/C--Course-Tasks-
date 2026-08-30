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
            throw new NotImplementedException();
        }
    }
}
