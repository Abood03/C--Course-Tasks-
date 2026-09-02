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
        /// <summary>
        /// Initializes a new librarian.
        /// </summary>
        /// <param name="id">The unique librarian identifier.</param>
        /// <param name="name">The librarian name.</param>
        public Librarian(int id, string name) : base(id, name)
        {
        }
    }
}
