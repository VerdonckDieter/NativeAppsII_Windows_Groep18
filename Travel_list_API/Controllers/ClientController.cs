using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IEnumerable<Client> GetClients() => _clientRepository.GetClients();

        [HttpGet("{email}")]
        public Client GetClientByEmail(string email) => _clientRepository.GetClientByEmail(email);

        [HttpPost]
        public ActionResult<Client> AddClient(Client client)
        {
            _clientRepository.AddClient(client);
            _clientRepository.SaveChanges();

            return CreatedAtAction(nameof(GetClientByEmail), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
            _clientRepository.UpdateClient(client);
            _clientRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{email}")]
        public ActionResult<Client> DeleteClient(string email)
        {
            Client client = _clientRepository.GetClientByEmail(email);
            if (client == null)
            {
                return NotFound();
            }
            _clientRepository.DeleteClient(client);
            _clientRepository.SaveChanges();
            return client;
        }
    }
}
