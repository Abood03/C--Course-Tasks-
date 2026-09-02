using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_LibraryManagementSystem.Interfaces
{
    /// <summary>
    /// Defines a search operation for items of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of item returned by the search.</typeparam>
    public interface ISearchable<T>
    {
        /// <summary>
        /// Searches for items that match the supplied text.
        /// </summary>
        /// <param name="query">The search text.</param>
        /// <returns>The matching items.</returns>
        List<T> Search(string query);
        
    }
}
