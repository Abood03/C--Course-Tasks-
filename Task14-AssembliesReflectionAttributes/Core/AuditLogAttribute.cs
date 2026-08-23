using System;

namespace Core
{
    // Defines where this custom attribute can be used.
    //
    // AttributeTargets.Method allows the attribute to be placed
    // on methods.
    //
    // AttributeTargets.Class allows the attribute to be placed
    // on classes.
    //
    // This means AuditLogAttribute can be used to mark both
    // classes and methods that we want to discover later
    // using Reflection.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuditLogAttribute : Attribute
    {
        // Stores a description explaining what the audited
        // class or method represents.
        //
        // Reflection will later read this value at runtime.
        public string description;

        // Constructor of the custom attribute.
        //
        // When the attribute is used, a description must be passed.
        //
        // Example:
        // [AuditLog("Create Employee")]
        //
        // The value "Create Employee" will be stored
        // inside the description field.
        public AuditLogAttribute(string description)
        {
            this.description = description;
        }
    }
}