using Capstone_LibraryManagementSystem.Exceptions;
using Capstone_LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Manages books, members, borrowing, searching, and data persistence.
    /// </summary>
    public class LibraryService : ISearchable<Book>
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        /// <summary>
        /// Occurs after a member successfully borrows a book.
        /// </summary>
        public event Action<Book, Member>? OnBookBorrowed;
        /// <summary>
        /// Adds a book to the library.
        /// </summary>
        /// <param name="book">The book to add.</param>
        /// <exception cref="LibraryException">
        /// Thrown when another book has the same identifier.
        /// </exception>
        [AuditLog("Adds a new book")]
        public void AddBook(Book book)
        {
            if (books.Exists(b => b.Id == book.Id))
            {
                throw new LibraryException(
                    "A book with this ID already exists");
            }

            books.Add(book);
        }

        /// <summary>
        /// Adds a member to the library.
        /// </summary>
        /// <param name="member">The member to add.</param>
        /// <exception cref="LibraryException">
        /// Thrown when another member has the same identifier.
        /// </exception>
        [AuditLog("Adds a new member")]
        public void AddMember(Member member)
        {
            if (members.Exists(m => m.Id == member.Id))
            {
                throw new LibraryException(
                    "A member with this ID already exists");
            }

            members.Add(member);
        }

        /// <summary>
        /// Searches for books by title or author.
        /// </summary>
        /// <param name="query">The search text.</param>
        /// <returns>Books whose title or author contains the search text.</returns>
        [AuditLog("Searches for books")]
        public List<Book> Search(string query)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Title.Contains(
                        query,
                        StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(
                        query,
                        StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(book);
                }
            }

            return results;
        }

        /// <summary>
        /// Lends an available book to a registered member.
        /// </summary>
        /// <param name="bookId">The identifier of the book.</param>
        /// <param name="memberId">The identifier of the member.</param>
        /// <exception cref="LibraryException">
        /// Thrown when the book or member is missing, or the book is already borrowed.
        /// </exception>
        [AuditLog("Borrows a book")]
        public void BorrowBook(int bookId, int memberId)
        {
            Book? book = books.Find(b => b.Id == bookId);
            Member? member = members.Find(m => m.Id == memberId);

            if (book == null)
            {
                throw new LibraryException("Book not found");
            }

            if (member == null)
            {
                throw new LibraryException("Member not found");
            }

            if (book.IsBorrowed)
            {
                throw new LibraryException(
                    "Book is already borrowed");
            }

            book.Borrow();
            member.BorrowedBooks.Add(book);

            OnBookBorrowed?.Invoke(book, member);

            Console.WriteLine(
                $"{member.Name} borrowed {book.Title}");
        }

        /// <summary>
        /// Returns a book borrowed by a registered member.
        /// </summary>
        /// <param name="bookId">The identifier of the book.</param>
        /// <param name="memberId">The identifier of the member.</param>
        /// <exception cref="LibraryException">
        /// Thrown when the book or member is missing, the book is available,
        /// or the member did not borrow it.
        /// </exception>
        [AuditLog("Returns a borrowed book")]
        public void ReturnBook(int bookId, int memberId)
        {
            Book? book = books.Find(b => b.Id == bookId);
            Member? member = members.Find(m => m.Id == memberId);

            if (book == null)
            {
                throw new LibraryException("Book not found");
            }

            if (member == null)
            {
                throw new LibraryException("Member not found");
            }

            if (!book.IsBorrowed)
            {
                throw new LibraryException(
                    "Book is not borrowed");
            }

            if (!member.BorrowedBooks.Contains(book))
            {
                throw new LibraryException(
                    "This member did not borrow this book");
            }

            book.Return();
            member.BorrowedBooks.Remove(book);

            Console.WriteLine(
                $"{member.Name} returned {book.Title}");
        }

        /// <summary>
        /// Saves all library data to a JSON file asynchronously.
        /// </summary>
        /// <param name="filePath">The destination JSON file path.</param>
        /// <returns>A task representing the save operation.</returns>
        [AuditLog("Saves library data to JSON")]
        public async Task SaveDataAsync(string filePath)
        {
            LibraryData data = new LibraryData
            {
                Books = books,
                Members = members
            };

            JsonSerializerOptions options =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };

            string json =
                JsonSerializer.Serialize(data, options);

            await File.WriteAllTextAsync(filePath, json);
        }

        /// <summary>
        /// Loads library data from a JSON file asynchronously.
        /// </summary>
        /// <param name="filePath">The source JSON file path.</param>
        /// <returns>A task representing the load operation.</returns>
        /// <exception cref="LibraryException">
        /// Thrown when the JSON data cannot be deserialized.
        /// </exception>
        [AuditLog("Loads library data from JSON")]
        public async Task LoadDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string json =
                await File.ReadAllTextAsync(filePath);

            LibraryData? data =
                JsonSerializer.Deserialize<LibraryData>(json);

            if (data == null)
            {
                throw new LibraryException(
                    "Could not load library data");
            }

            books = data.Books ?? new List<Book>();
            members = data.Members ?? new List<Member>();

            foreach (Member member in members)
            {
                List<Book> restoredBooks = new List<Book>();

                foreach (Book borrowedBook
                         in member.BorrowedBooks)
                {
                    Book? originalBook =
                        books.Find(
                            b => b.Id == borrowedBook.Id);

                    if (originalBook != null)
                    {
                        restoredBooks.Add(originalBook);
                    }
                }

                member.BorrowedBooks = restoredBooks;
            }
        }
    }
}