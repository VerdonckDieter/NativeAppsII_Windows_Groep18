using System.Collections.Generic;

namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents a category DTO.
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// Gets or sets the category DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the category DTO's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category DTO's items.
        /// </summary>
        public List<Item> Items { get; set; }
    }
}
