using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the categories backend.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Adds a new category if the category does not exist, updates the 
        /// existing category otherwise.
        /// </summary>
        Task<Category> UpsertCategoryAsync(int tripId, Category category);

        /// <summary>
        /// Deletes a category.
        /// </summary>
        Task<bool> DeleteCategoryAsync(int tripId, int categoryId);
    }
}
