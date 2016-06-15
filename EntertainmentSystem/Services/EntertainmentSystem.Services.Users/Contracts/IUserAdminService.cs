namespace EntertainmentSystem.Services.Users.Contracts
{
    using System.Linq;
    using EntertainmentSystem.Data.Models;

    public interface IUserAdminService : IUserModeratorService
    {
        /// <summary>
        /// Get all users. With ordinary deleted.
        /// </summary>
        /// <returns>Users as queryable.</returns>
        IQueryable<ApplicationUser> GetAllWithDeleted();

        /// <summary>
        /// Delete user.
        /// </summary>
        /// <param name="user">User to be deleted.</param>
        void DeletePermanent(ApplicationUser user);
    }
}
