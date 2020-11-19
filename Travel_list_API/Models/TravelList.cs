using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public class TravelList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Item> Items { get; private set; }
        public ICollection<Task> Tasks { get; private set; }

        public TravelList() {
            Items = new List<Item>();
            Tasks = new List<Task>();
        }

        public TravelList(String Name, DateTime StartDate, DateTime EndDate)
        {
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public void AddItem(Item item) => Items.Add(item);

        public void RemoveItem(Item item) => Items.Remove(item);

        public void AddTask(Task task) => Tasks.Add(task);

        public void RemoveTask(Task task) => Tasks.Remove(task);
     }
}
