
namespace Travel_list_API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int TravelListId { get; set; }
        public string Name { get; set; }
        public Task() { }
    }
}
