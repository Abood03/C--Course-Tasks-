using System.Collections.Generic;

namespace Capstone_LibraryManagementSystem.Models
{
    public class LibraryData
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();
    }
}