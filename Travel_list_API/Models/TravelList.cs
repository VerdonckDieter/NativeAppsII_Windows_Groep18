using System;
using System.Collections.Generic;

namespace Travel_list_API.Models
{
    public class TravelList
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Item> Items { get; private set; }
        public List<Task> Tasks { get; private set; }
        public List<Category> Categories { get; set; }

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
