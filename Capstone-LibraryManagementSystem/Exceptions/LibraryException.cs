using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Exceptions
{
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
