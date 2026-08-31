using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Represents a library member and tracks borrowed books.
    /// </summary>
    public class Member : Person
    {
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        public Member(int id, string name) : base(id, name)
        {

        }

    }
}
