using System.Collections.ObjectModel;
using System.Linq;

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
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category's items.
        /// </summary>
        public ObservableCollection<Item> Items { get; set; }

        /// <summary>
        /// Gets the category's added items.
        /// </summary>
        public int ItemsAdded => Items.Count(i => i.Added);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new category.
        /// </summary>
        public Category() => Items = new ObservableCollection<Item>();
        #endregion
    }
}
