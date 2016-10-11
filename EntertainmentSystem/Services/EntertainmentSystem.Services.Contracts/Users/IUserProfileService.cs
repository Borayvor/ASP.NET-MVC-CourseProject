namespace EntertainmentSystem.Services.Contracts.Users
{
    using EntertainmentSystem.Data.Models;

    public interface IUserProfileService
    {
        /// <summary>
        /// Updates the profile of the user.
        /// </summary>
        /// <param name="entity">User to be updated.</param>
        void Update(ApplicationUser entity);
    }
}
