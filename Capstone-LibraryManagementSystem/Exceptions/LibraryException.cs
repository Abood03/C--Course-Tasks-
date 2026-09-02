using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Exceptions
{
    /// <summary>
    /// Represents an error caused by a library operation.
    /// </summary>
    public class LibraryException : Exception
    {
        /// <summary>
        /// Initializes a new library exception.
        /// </summary>
        public LibraryException()
        {
        }

        /// <summary>
        /// Initializes a new library exception with an error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LibraryException(string? message) : base(message)
        {
            
        }
    }
}
