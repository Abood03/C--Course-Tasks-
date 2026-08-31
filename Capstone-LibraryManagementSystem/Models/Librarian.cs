using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Represents a librarian in the library system.
    /// </summary>
    public class Librarian : Person
    {
        public Librarian(int id, string name) : base(id, name)
        {
        }
    }
}
