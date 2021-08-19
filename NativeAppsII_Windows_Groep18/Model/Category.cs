using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace NativeAppsII_Windows_Groep18.Model
{
    /// <summary>
    /// Represents a category.
    /// </summary>
    public class Category : INotifyPropertyChanged
    {
        #region Fields
        public event PropertyChangedEventHandler PropertyChanged;
        private int _itemsAdded;
        #endregion

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
        /// Gets or sets the category's added items.
        /// </summary>
        public int ItemsAdded
        {
            get => _itemsAdded;
            set
            {
                _itemsAdded = value;
                OnPropertyChanged(nameof(ItemsAdded));
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new category.
        /// </summary>
        public Category() => Items = new ObservableCollection<Item>();
        #endregion

        #region Methods
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateItemsAdded() => ItemsAdded = Items.Count(i => i.Added);
        #endregion
    }
}
