using System.Collections.Generic;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Stores the library data used for JSON serialization.
    /// </summary>
    public class LibraryData
    {
        /// <summary>
        /// Gets or sets the stored books.
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
        /// <summary>
        /// Gets or sets the stored members.
        /// </summary>
        public List<Member> Members { get; set; } = new List<Member>();
    }
}