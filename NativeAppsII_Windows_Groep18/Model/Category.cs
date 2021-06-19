using System.Collections.ObjectModel;

namespace NativeAppsII_Windows_Groep18.Model
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
        public ObservableCollection<Item> Items { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new category.
        /// </summary>
        public Category() => Items = new ObservableCollection<Item>();
        #endregion
    }
}
