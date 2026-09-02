using System;

namespace Capstone_LibraryManagementSystem.Models
{
    /// <summary>
    /// Adds an audit description to a library operation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditLogAttribute : Attribute
    {
        /// <summary>
        /// Gets the description of the audited operation.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes a new audit log attribute.
        /// </summary>
        /// <param name="description">The operation description.</param>
        public AuditLogAttribute(string description)
        {
            Description = description;
        }
    }
}