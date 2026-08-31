using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines operations for objects that can be borrowed and returned.
    /// </summary>
    public interface IBorrowable
    {
        public void Borrow();
        public void Return();
    }
}
