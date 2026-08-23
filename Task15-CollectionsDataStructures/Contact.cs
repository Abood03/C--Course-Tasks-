using System;
using System.Collections.Generic;
using System.Text;

namespace Task15_CollectionsDataStructures
{
    public class Contact
    {
        public int Id;
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public Contact(int id, string name, string email, string city)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
        }
        public Contact()
        {
            
        }
        public override string ToString()
        {
            return $"{{Id:{Id} ,Name:{Name} ,Email:{Email} ,City:{City}}}";
        }
        
    }
}
