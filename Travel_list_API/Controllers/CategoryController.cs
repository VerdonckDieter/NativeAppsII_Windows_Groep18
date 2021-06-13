using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.DTO;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Controllers
{
    /// <summary>
    /// Contains methods for interacting with category data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(Policy = "User")]
    public class CategoryController : ControllerBase
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public CategoryController(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new category or updates an existing one.
        /// </summary>
        [HttpPost("{tripId}")]
        public async Task<ActionResult> PostCategory(int tripId, CategoryDTO categoryDTO)
        {
            var category = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Items = categoryDTO.Items
            };
            return Ok(await _categoryRepository.UpsertCategoryAsync(tripId, category));
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        [HttpDelete("{tripId}/{categoryId}")]
        public async Task<ActionResult> DeleteCategory(int tripId, int categoryId)
        {
            return Ok(await _categoryRepository.DeleteCategoryAsync(tripId, categoryId));
        } 
        #endregion
    }
}
