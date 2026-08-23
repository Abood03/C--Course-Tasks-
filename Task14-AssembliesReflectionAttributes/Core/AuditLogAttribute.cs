using System;
using System.Collections.Generic;
using System.Text;
namespace Core
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class)]
    public class AuditLogAttribute : Attribute
    {
        public string description;

        public AuditLogAttribute(string description)
        {
            this.description = description;
        }
    }
}
