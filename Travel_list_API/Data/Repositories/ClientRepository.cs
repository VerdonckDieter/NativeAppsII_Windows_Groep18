using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly TravelListContext _dbContext;
        private readonly DbSet<Client> _clients;
        public ClientRepository(TravelListContext dbContext)
        {
            _dbContext = dbContext;
            _clients = dbContext.Clients;
        }

        public void AddClient(Client client) => _clients.AddAsync(client);

        public void DeleteClient(Client client) => _clients.Remove(client);

        public Client GetClientByEmail(string email) => _clients.AsNoTracking().Include(c => c.TravelLists).SingleOrDefault(c => c.Email == email);

        public IEnumerable<Client> GetClients() => _clients.AsNoTracking().Include(c => c.TravelLists).ToList();

        public void UpdateClient(Client client) => _clients.Update(client);

        public void SaveChanges() => _dbContext.SaveChanges();
    }
}
