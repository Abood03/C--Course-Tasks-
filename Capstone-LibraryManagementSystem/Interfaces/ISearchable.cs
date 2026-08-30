using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    public interface ISearchable<T>
    {
        List<T> Search(string query);
        
    }
}
