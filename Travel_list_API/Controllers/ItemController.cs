using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with items data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Policy = "User")]
    public class ItemController : ControllerBase
    {
        #region Fields
        private readonly IItemRepository _itemRepository;
        #endregion

        #region Constructors
        public ItemController(IItemRepository itemRepository) => _itemRepository = itemRepository;
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new item or updates an existing one.
        /// </summary>
        [HttpPost("{categoryId}")]
        public async Task<ActionResult> PostItem(ItemDTO itemDTO, int categoryId)
        {
            var item = new Item()
            {
                Id = itemDTO.Id,
                CategoryId = itemDTO.CategoryId,
                Name = itemDTO.Name,
                Amount = itemDTO.Amount,
                Added = itemDTO.Added
            };
            return Ok(await _itemRepository.UpsertItemAsync(categoryId, item));
        }

        /// <summary>
        /// Deletes an item.
        /// </summary>
        [HttpDelete("{categoryId}/{itemId}")]
        public async Task<ActionResult> DeleteItem(int categoryId, int itemId)
        {
            return Ok(await _itemRepository.DeleteItemAsync(categoryId, itemId));
        } 
        #endregion
    }
}
