using Capstone_LibraryManagementSystem.Exceptions;
using Capstone_LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capstone_LibraryManagementSystem.Models
{
    public class LibraryService : ISearchable<Book>
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public event Action<Book, Member>? OnBookBorrowed;

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void AddMember(Member member)
        {
            members.Add(member);
        }

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
                throw new LibraryException("Book is already borrowed");
            }

            book.Borrow();
            member.BorrowedBooks.Add(book);

            OnBookBorrowed?.Invoke(book, member);

            Console.WriteLine($"{member.Name} borrowed {book.Title}");
        }

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
                throw new LibraryException("Book is not borrowed");
            }

            if (!member.BorrowedBooks.Contains(book))
            {
                throw new LibraryException(
                    "This member did not borrow this book");
            }

            book.Return();
            member.BorrowedBooks.Remove(book);

            Console.WriteLine($"{member.Name} returned {book.Title}");
        }

        public async Task SaveDataAsync(string filePath)
        {
            LibraryData data = new LibraryData
            {
                Books = books,
                Members = members
            };

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);

            await File.WriteAllTextAsync(filePath, json);
        }
        public async Task LoadDataAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string json = await File.ReadAllTextAsync(filePath);

            LibraryData? data =
                JsonSerializer.Deserialize<LibraryData>(json);

            if (data == null)
            {
                throw new LibraryException("Could not load library data");
            }

            books = data.Books ?? new List<Book>();
            members = data.Members ?? new List<Member>();

            // Reconnect borrowed books with the main books list
            foreach (Member member in members)
            {
                List<Book> restoredBooks = new List<Book>();

                foreach (Book borrowedBook in member.BorrowedBooks)
                {
                    Book? originalBook =
                        books.Find(b => b.Id == borrowedBook.Id);

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