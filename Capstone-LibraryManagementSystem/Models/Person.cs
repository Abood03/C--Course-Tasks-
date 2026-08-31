using System;


namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Defines shared information for people in the library system.
    /// </summary>
    public abstract class Person
    {

        public int Id { get; set; }
        public string Name { get; set; }
        protected Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id is :{Id}, Name is :{Name}";
        }
    }
}
