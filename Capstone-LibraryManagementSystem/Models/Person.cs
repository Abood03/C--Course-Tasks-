using System;


namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Defines the shared data for people in the library system.
    /// </summary>
    public abstract class Person
    {

        /// <summary>
        /// Gets or sets the person's unique identifier.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the person's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Initializes the shared person data.
        /// </summary>
        /// <param name="id">The unique person identifier.</param>
        /// <param name="name">The person's name.</param>
        protected Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Returns the person's identifier and name.
        /// </summary>
        /// <returns>A formatted description of the person.</returns>
        public override string ToString()
        {
            return $"Id is :{Id}, Name is :{Name}";
        }
    }
}
