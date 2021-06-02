using System;
using System.Collections.Generic;

namespace Travel_list_API.Models
{
    public class Client
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<TravelList> TravelLists { get; set; }

        public Client()
        {
            TravelLists = new List<TravelList>();
        }

        public Client(string email, string firstname, string lastname)
        {
            Email = email;
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddTravelList(TravelList travelList) => TravelLists.Add(travelList);

        public void RemoveTravelList(TravelList travelList) => TravelLists.Remove(travelList);
    }
}
