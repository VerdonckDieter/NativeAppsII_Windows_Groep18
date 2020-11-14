using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travel_list_API.Models;

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

        [HttpGet]
        public IEnumerable<TravelList> GetTravelLists() => _travelListRepository.GetTravelLists();

        [HttpGet("{id}")]
        public TravelList GetTravelListById(int id) => _travelListRepository.GetTravelListById(id);

        [HttpPost]
        public ActionResult<TravelList> PostTravelList(TravelList travelList)
        {
            _travelListRepository.Add(travelList);
            _travelListRepository.SaveChanges();

            return CreatedAtAction(nameof(GetTravelListById), new { id = travelList.Id }, travelList);
        }

        [HttpPut("{id}")]
        public IActionResult PutTravelList(int id, TravelList travelList)
        {
            if (id != travelList.Id)
            {
                return BadRequest();
            }
            _travelListRepository.Update(travelList);
            _travelListRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<TravelList> DeleteTravelList(int id)
        {
            TravelList travelList = _travelListRepository.GetTravelListById(id);
            if (travelList == null)
            {
                return NotFound();
            }
            _travelListRepository.Delete(travelList);
            _travelListRepository.SaveChanges();
            return travelList;
        }

    }
}
