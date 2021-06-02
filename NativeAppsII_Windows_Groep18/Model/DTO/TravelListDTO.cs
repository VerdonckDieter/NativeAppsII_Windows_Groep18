using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAppsII_Windows_Groep18.Model.DTO
{
    public class TravelListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Itinerary Itinerary { get; set; }
    }
}
