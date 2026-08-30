using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Models
{
    public class Book
    {

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; } = false;
        public Book(int id, string title, string author)
        {
            Id = id;
            Author = author;
            Title = title;
        }
        public override string ToString()
        {
            string status = IsBorrowed ? "Borrowed" : "Available";

            return $"Id: {Id}, Title: {Title}, Author: {Author}, Status: {status}";
        }

    }

}
