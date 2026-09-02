using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines operations for an item that can be borrowed and returned.
    /// </summary>
    public interface IBorrowable
    {
        /// <summary>
        /// Marks the item as borrowed.
        /// </summary>
        public void Borrow();
        /// <summary>
        /// Marks the item as returned.
        /// </summary>
        public void Return();
    }
}
