using System;

namespace Capstone_LibraryManagementSystem.Models
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditLogAttribute : Attribute
    {
        public string Description { get; }

        public AuditLogAttribute(string description)
        {
            Description = description;
        }
    }
}