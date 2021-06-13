using System.Collections.Generic;

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

        /// <summary>
        /// Gets or sets the category's items.
        /// </summary>
        public List<Item> Items { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new category.
        /// </summary>
        public Category() => Items = new List<Item>();
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new item to the category.
        /// </summary>
        public void AddItem(Item item) => Items.Add(item);

        /// <summary>
        /// Removes an item from the category.
        /// </summary>
        public void RemoveItem(Item item) => Items.Remove(item); 
        #endregion
    }
}
