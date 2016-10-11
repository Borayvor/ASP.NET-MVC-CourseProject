﻿namespace EntertainmentSystem.Services.Contracts.Users
{
    using System.Linq;
    using Data.Models;

    public interface IUserAdminService : IUserModeratorService, IUserProfileService
    {
        /// <summary>
        /// Get all users. With ordinary deleted.
        /// </summary>
        /// <returns>Users as queryable.</returns>
        IQueryable<ApplicationUser> GetAllWithDeleted();

        /// <summary>
        /// Delete user permanent.
        /// </summary>
        /// <param name="entity">User to be deleted.</param>
        void DeletePermanent(ApplicationUser entity);
    }
}
