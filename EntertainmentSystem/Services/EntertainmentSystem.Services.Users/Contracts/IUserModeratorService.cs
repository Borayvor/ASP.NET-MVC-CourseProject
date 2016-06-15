namespace EntertainmentSystem.Services.Users.Contracts
{
    using System.Linq;
    using EntertainmentSystem.Data.Models;

    public interface IUserModeratorService
    {
        /// <summary>
        /// Get all users. Without ordinary deleted.
        /// </summary>
        /// <returns>Users as queryable.</returns>
        IQueryable<ApplicationUser> GetAll();

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="userId">The id of the user to get.</param>
        /// <returns>User as class.</returns>
        ApplicationUser GetUser(string userId);

        /// <summary>
        /// Delete user. Not permanent.
        /// </summary>
        /// <param name="user">User to be deleted.</param>
        void Delete(ApplicationUser user);
    }
}
