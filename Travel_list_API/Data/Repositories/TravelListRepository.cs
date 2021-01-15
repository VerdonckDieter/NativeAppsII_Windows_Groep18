using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Travel_list_API.Models;

namespace Travel_list_API.Data.Repositories
{
    public class TravelListRepository : ITravelListRepository
    {
        private readonly TravelListContext _dbContext;
        private readonly DbSet<TravelList> _travelLists;
        private readonly DbSet<Client> _clients;
        public TravelListRepository(TravelListContext dbContext)
        {
            _dbContext = dbContext;
            _travelLists = dbContext.TravelLists;
            _clients = dbContext.Clients;
        }

        public void AddTravelList(int clientId, TravelList travelList)
        {
            Client client = GetClientById(clientId, true);
            client.AddTravelList(travelList);
            _clients.Update(client);
            //_travelLists.AddAsync(travelList);
        }

        public void DeleteTravelList(int clientId, TravelList travelList)
        {
            Client client = GetClientById(clientId, true);
            client.RemoveTravelList(travelList);
            _clients.Update(client);
            //_travelLists.Remove(travelList);
        }

        public TravelList GetTravelListById(int clientId, int travelListId)
        {
            return GetClientById(clientId, false).TravelLists.Single(t => t.Id == travelListId);
            //_travelLists.Include(t => t.Items).SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<TravelList> GetTravelLists(int clientId)
        {
            return GetClientById(clientId, false).TravelLists;
            //_travelLists.Include(t => t.Items).ToList();
        }


        public void UpdateTravelList(TravelList travelList)
        {
            _travelLists.Update(travelList);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private Client GetClientById(int id, bool tracking)
        {
            return tracking ? _clients
                .Include(c => c.TravelLists).ThenInclude(t => t.Items)
                .Include(c => c.TravelLists).ThenInclude(t => t.Tasks)
                .Include(c => c.TravelLists).ThenInclude(t => t.Categories)
                .Include(c => c.TravelLists).ThenInclude(t => t.Itinerary)
                .First(c => c.Id == id) :
                _clients
                .Include(c => c.TravelLists).ThenInclude(t => t.Items)
                .Include(c => c.TravelLists).ThenInclude(t => t.Tasks)
                .Include(c => c.TravelLists).ThenInclude(t => t.Categories)
                .Include(c => c.TravelLists).ThenInclude(t => t.Itinerary)
                .AsNoTracking()
                .First(c => c.Id == id);
        }
    }
}
