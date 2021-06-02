using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int TravelListId { get; set; }
        public string Name { get; set; }
        public Category() { }
    }
}
