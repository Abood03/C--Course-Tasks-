using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines a generic search operation.
    /// </summary>
    public interface ISearchable<T>
    {
        List<T> Search(string query);
        
    }
}
