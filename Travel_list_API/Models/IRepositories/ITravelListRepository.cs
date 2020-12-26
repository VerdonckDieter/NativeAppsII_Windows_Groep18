using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public interface ITravelListRepository
    {
        IEnumerable<TravelList> GetTravelLists(int clientId); 
        TravelList GetTravelListById(int clientId, int travelListId); 
        void AddTravelList(int clientId, TravelList travelList); 
        void UpdateTravelList(TravelList travelList); 
        void DeleteTravelList(int clientId, TravelList travelList); 
        void SaveChanges();
    }
}
