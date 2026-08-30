using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    public interface IBorrowable
    {
        public void Borrow();
        public void Return();
    }
}
