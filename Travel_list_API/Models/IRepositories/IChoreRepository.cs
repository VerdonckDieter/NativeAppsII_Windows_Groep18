using System.Threading.Tasks;

namespace Travel_list_API.Models.IRepositories
{
    /// <summary>
    /// Defines methods for interacting with the chores backend.
    /// </summary>
    public interface IChoreRepository
    {
        /// <summary>
        /// Adds a new chore if the chore does not exist, updates the 
        /// existing chore otherwise.
        /// </summary>
        Task<Chore> UpsertChoreAsync(int tripId, Chore chore);

        /// <summary>
        /// Deletes a chore.
        /// </summary>
        Task<bool> DeleteChoreAsync(int tripId, int choreId);
    }
}
