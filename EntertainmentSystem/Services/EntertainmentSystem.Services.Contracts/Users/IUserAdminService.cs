namespace EntertainmentSystem.Services.Contracts.Users
{
    using System.Linq;
    using Data.Models;

    public interface IUserAdminService : IUserModeratorService
    {
        /// <summary>
        /// Get all users. With ordinary deleted.
        /// </summary>
        /// <returns>Users as queryable.</returns>
        IQueryable<ApplicationUser> GetAllWithDeleted();

        /// <summary>
        /// Delete user permanent.
        /// </summary>
        /// <param name="user">User to be deleted.</param>
        void DeletePermanent(ApplicationUser user);
    }
}
