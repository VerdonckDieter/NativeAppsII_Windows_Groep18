namespace NativeAppsII_Windows_Groep18.Model
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
        /// Gets or sets the item's category id.
        /// </summary>
        public int CategoryId { get; set; }

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
        /// Gets the item's display name.
        /// </summary>
        public string DisplayName => $"{Name}({Amount})";
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new item.
        /// </summary>
        public Item() { }
        #endregion
    }
}
