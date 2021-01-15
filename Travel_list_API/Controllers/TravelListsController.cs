using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;

namespace Travel_list_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelListsController : ControllerBase
    {
        private readonly ITravelListRepository _travelListRepository;
        public TravelListsController(ITravelListRepository travelListRepository)
        {
            _travelListRepository = travelListRepository;
        }

        [HttpGet("{clientId}/travelLists")]
        public IEnumerable<TravelList> GetTravelLists(int clientId)
        {
            return _travelListRepository.GetTravelLists(clientId);
        }

        [HttpGet("{clientId}/travelLists/{travelListId}")]
        public TravelList GetTravelListById(int clientId, int travelListId)
        {
            return _travelListRepository.GetTravelListById(clientId, travelListId);
        }

        [HttpPost("{clientId}")]
        public ActionResult<TravelList> PostTravelList(int clientId, TravelListDTO travelListDTO)
        {
            var travelList = new TravelList()
            {
                Id = travelListDTO.Id,
                ClientId = clientId,
                Name = travelListDTO.Name,
                StartDate = travelListDTO.StartDate,
                EndDate = travelListDTO.EndDate,
                Items = travelListDTO.Items,
                Tasks = travelListDTO.Tasks,
                Categories = travelListDTO.Categories,
                Itinerary = travelListDTO.Itinerary
            };
            _travelListRepository.AddTravelList(clientId, travelList);
            _travelListRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTravelListById), new { clientId, travelListId = travelList.Id }, travelList);
        }

        [HttpPut("{travelListId}")]
        public IActionResult PutTravelList(int travelListId, TravelList travelList)
        {
            if (travelListId != travelList.Id)
            {
                return BadRequest();
            }
            _travelListRepository.UpdateTravelList(travelList);
            _travelListRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{clientId}/travelLists/{travelListId}")]
        public ActionResult<TravelList> DeleteTravelList(int clientId, int travelListId)
        {
            TravelList travelList = _travelListRepository.GetTravelListById(clientId, travelListId);
            if (travelList == null)
            {
                return NotFound();
            }
            _travelListRepository.DeleteTravelList(clientId, travelList);
            _travelListRepository.SaveChanges();
            return travelList;
        }
    }
}
