using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category
    {
        #region Properties
        /// <summary>
        /// Gets or sets the category's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the category's name.
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new category.
        /// </summary>
        public Category() { } 
        #endregion
    }
}
