using Capstone_LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    public class LibraryService : ISearchable<Book>
    {
        private List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public List<Book> Search(string query)
        {
            List<Book> results = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Title.Contains(query, StringComparison.OrdinalIgnoreCase)||
                    book.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(book);
                }
                
            }
            if (results.Count == 0)
            {
                Console.WriteLine("Nothing found");
            }

            return results;
        }
        private List<Member> members = new List<Member>();
        public void AddMember(Member member)
        {
            members.Add(member);
        }
        public void BorrowBook(int bookId, int memberId)
        {
            Book book = books.Find(b => b.Id == bookId);
            Member member = members.Find(m => m.Id == memberId);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }
            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }
            if (book.IsBorrowed)
            {
                Console.WriteLine("Book is already borrowed");
                return;
            }
            book.Borrow();
            member.BorrowedBooks.Add(book);
            OnBookBorrowed?.Invoke(book, member);

            Console.WriteLine($"{member.Name} borrowed {book.Title}");  
        }
        public void ReturnBook(int bookId, int memberId)
        {
            Book book = books.Find(b => b.Id == bookId);
            Member member = members.Find(m => m.Id == memberId);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Member not found");
                return;
            }

            if (!book.IsBorrowed)
            {
                Console.WriteLine("Book is not borrowed");
                return;
            }

            if (!member.BorrowedBooks.Contains(book))
            {
                Console.WriteLine("This member did not borrow this book");
                return;
            }

            book.Return();
            member.BorrowedBooks.Remove(book);

            Console.WriteLine($"{member.Name} returned {book.Title}");
        }
        public event Action<Book, Member>? OnBookBorrowed;
    }
}
