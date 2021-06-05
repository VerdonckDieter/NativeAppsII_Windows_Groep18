namespace Travel_list_API.Models
{
    /// <summary>
    /// Represents an item.
    /// </summary>
    public class Item
    {
        #region Properties
        /// <summary>
        /// Gets or sets the item's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item's amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the item is added.
        /// </summary>
        public bool Added { get; set; }

        /// <summary>
        /// Gets or sets the item's category.
        /// </summary>
        public Category Category { get; set; } 
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new item.
        /// </summary>
        public Item() { }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="name">The item's name</param>
        /// <param name="amount">The item's amount</param>
        /// <param name="added">Wether the item is added</param>
        public Item(string name, int amount, bool added)
        {
            Name = name;
            Amount = amount;
            Added = added;
        } 
        #endregion
    }
}
