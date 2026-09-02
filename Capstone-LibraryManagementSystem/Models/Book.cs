using Capstone_LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Represents a book stored in the library.
    /// </summary>
    public class Book:IBorrowable
    {

        /// <summary>
        /// Gets or sets the unique book identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets the book title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets whether the book is currently borrowed.
        /// </summary>
        public bool IsBorrowed { get; set; } = false;
        /// <summary>
        /// Initializes a new book.
        /// </summary>
        /// <param name="id">The unique book identifier.</param>
        /// <param name="title">The book title.</param>
        /// <param name="author">The book author.</param>
        public Book(int id, string title, string author)
        {
            Id = id;
            Author = author;
            Title = title;
        }
        /// <summary>
        /// Returns the book details and borrowing status.
        /// </summary>
        /// <returns>A formatted description of the book.</returns>
        public override string ToString()
        {
            string status = IsBorrowed ? "Borrowed" : "Available";

            return $"Id: {Id}, Title: {Title}, Author: {Author}, Status: {status}";
        }

        /// <summary>
        /// Marks the book as borrowed.
        /// </summary>
        public void Borrow()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
            }
        }

        /// <summary>
        /// Marks the book as available.
        /// </summary>
        public void Return()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
            }
        }
    }
}