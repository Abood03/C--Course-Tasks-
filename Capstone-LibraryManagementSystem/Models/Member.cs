using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Represents a library member who can borrow books.
    /// </summary>
    public class Member : Person
    {
        /// <summary>
        /// Gets or sets the books currently borrowed by the member.
        /// </summary>
        public List<Book> BorrowedBooks { get; set; } = new List<Book>();
        /// <summary>
        /// Initializes a new library member.
        /// </summary>
        /// <param name="id">The unique member identifier.</param>
        /// <param name="name">The member name.</param>
        public Member(int id, string name) : base(id, name)
        {

        }

    }
}
