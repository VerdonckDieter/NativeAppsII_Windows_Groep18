using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with chores data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Policy = "User")]
    public class ChoreController : ControllerBase
    {
        #region Fields
        private readonly IChoreRepository _choreRepository;
        #endregion


        #region Constructors
        public ChoreController(IChoreRepository choreRepository) => _choreRepository = choreRepository;
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new chore or updates an existing one.
        /// </summary>
        [HttpPost("{tripId}")]
        public async Task<ActionResult> PostChore(int tripId, ChoreDTO choreDTO)
        {
            var chore = new Chore()
            {
                Id = choreDTO.Id,
                Name = choreDTO.Name,
                Completed = choreDTO.Completed
            };
            return Ok(await _choreRepository.UpsertChoreAsync(tripId, chore));
        }

        /// <summary>
        /// Deletes a chore.
        /// </summary>
        [HttpDelete("{tripId}/{choreId}")]
        public async Task<ActionResult> DeleteChore(int tripId, int choreId)
        {
            return Ok(await _choreRepository.DeleteChoreAsync(tripId, choreId));
        } 
        #endregion
    }
}
