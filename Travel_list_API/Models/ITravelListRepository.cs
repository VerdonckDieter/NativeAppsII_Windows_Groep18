using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public interface ITravelListRepository
    {
        IEnumerable<TravelList> GetTravelLists(); 
        TravelList GetTravelListById(int id); 
        void Add(TravelList travelList); 
        void Update(TravelList travelList); 
        void Delete(TravelList travelList); 
        void SaveChanges();
    }
}
