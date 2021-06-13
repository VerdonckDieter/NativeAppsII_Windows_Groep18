using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Travel_list_API.Models;
using Travel_list_API.Models.IRepositories;

namespace Travel_list_API.Data.Repositories
{
    /// <summary>
    /// Contains methods for interacting with the categories backend using 
    /// SQL via Entity Framework Core.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        #region Fields
        private readonly Context _db;
        #endregion

        #region Constructors
        public CategoryRepository(Context db) => _db = db;
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new category if the category does not exist, updates the 
        /// existing category otherwise.
        /// </summary>
        public async Task<Category> UpsertCategoryAsync(int tripId, Category category)
        {
            var current = await _db.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            if (current == null)
            {
                var trip = await GetTrip(tripId);
                trip.AddCategory(category);
                _db.Trips.Update(trip);
            }
            else
            {
                _db.Entry(current).CurrentValues.SetValues(category);
            }
            await _db.SaveChangesAsync();
            return category;
        }

        /// <summary>
        /// Deletes a category.
        /// </summary>
        public async Task<bool> DeleteCategoryAsync(int tripId, int categoryId)
        {
            var trip = await GetTrip(tripId);
            trip.RemoveCategory(trip.Categories.Single(c => c.Id == categoryId));
            _db.Trips.Update(trip);
            return await _db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Returns the trip associated with the given id.
        /// </summary>
        private async Task<Trip> GetTrip(int id)
        {
            return await _db.Trips
                .Include(t => t.Categories).ThenInclude(c => c.Items)
                .SingleAsync(t => t.Id == id);
        }
        #endregion
    }
}
