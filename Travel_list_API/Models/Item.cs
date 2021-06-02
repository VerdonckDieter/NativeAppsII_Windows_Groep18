
namespace Travel_list_API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int TravelListId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Added { get; set; }
        public string Category { get; set; }

        public Item(){ }

        public Item(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public void ChangeAmount(int amount) => Amount = amount;
    }
}
