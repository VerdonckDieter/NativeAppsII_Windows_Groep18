using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientByEmail(string email);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        void SaveChanges();
    }
}
