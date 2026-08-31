using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Exceptions
{
    /// <summary>
    /// Represents errors raised by library operations.
    /// </summary>
    public class LibraryException : Exception
    {
        public LibraryException()
        {
        }

        public LibraryException(string? message) : base(message)
        {
            
        }
    }
}
