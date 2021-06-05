//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Travel_list_API.Models;
//using Travel_list_API.Models.DTO;

//namespace Travel_list_API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TravelListsController : ControllerBase
//    {
//        private readonly ITravelListRepository _travelListRepository;
//        public TravelListsController(ITravelListRepository travelListRepository)
//        {
//            _travelListRepository = travelListRepository;
//        }

//        [HttpGet("{clientId}/travelLists")]
//        public IEnumerable<Trip> GetTravelLists(int clientId)
//        {
//            return _travelListRepository.GetTravelLists(clientId);
//        }

//        [HttpGet("{clientId}/travelLists/{travelListId}")]
//        public Trip GetTravelListById(int clientId, int travelListId)
//        {
//            return _travelListRepository.GetTravelListById(clientId, travelListId);
//        }

//        [HttpPost("{clientId}")]
//        public ActionResult<Trip> PostTravelList(int clientId, TripDTO travelListDTO)
//        {
//            var travelList = new Trip()
//            {
//                Id = travelListDTO.Id,
//                ClientId = clientId,
//                Name = travelListDTO.Name,
//                StartDate = travelListDTO.StartDate,
//                EndDate = travelListDTO.EndDate,
//                Items = travelListDTO.Items,
//                Tasks = travelListDTO.Tasks,
//                Categories = travelListDTO.Categories,
//                Itinerary = travelListDTO.Itinerary
//            };
//            _travelListRepository.AddTravelList(clientId, travelList);
//            _travelListRepository.SaveChanges();

//            return CreatedAtAction(nameof(GetTravelListById), new { clientId, travelListId = travelList.Id }, travelList);
//        }

//        [HttpPut("{clientId}/travelLists/{travelListId}")]
//        public IActionResult PutTravelList(int clientId, int travelListId, TripDTO travelListDTO)
//        {
//            if (travelListId != travelListDTO.Id)
//            {
//                return BadRequest();
//            }
//            var travelList = new Trip()
//            {
//                Id = travelListDTO.Id,
//                ClientId = clientId,
//                Name = travelListDTO.Name,
//                StartDate = travelListDTO.StartDate,
//                EndDate = travelListDTO.EndDate,
//                Items = travelListDTO.Items
//            };
//            _travelListRepository.UpdateTravelList(travelList);
//            _travelListRepository.SaveChanges();

//            return NoContent();
//        }

//        [HttpDelete("{clientId}/travelLists/{travelListId}")]
//        public ActionResult<Trip> DeleteTravelList(int clientId, int travelListId)
//        {
//            Trip travelList = _travelListRepository.GetTravelListById(clientId, travelListId);
//            if (travelList == null)
//            {
//                return NotFound();
//            }
//            _travelListRepository.DeleteTravelList(clientId, travelList);
//            _travelListRepository.SaveChanges();
//            return travelList;
//        }
//    }
//}
