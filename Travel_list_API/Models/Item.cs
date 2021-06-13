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
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new item.
        /// </summary>
        public Item() { }
        #endregion
    }
}
