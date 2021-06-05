using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models.DTO
{
    /// <summary>
    /// Represents an item DTO.
    /// </summary>
    public class ItemDTO
    {
        /// <summary>
        /// Gets or sets the item DTO's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the item DTO's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the item DTO's amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wether the item DTO is added.
        /// </summary>
        public bool Added { get; set; }

        /// <summary>
        /// Gets or sets the item DTO's category.
        /// </summary>
        public Category Category { get; set; }
    }
}
