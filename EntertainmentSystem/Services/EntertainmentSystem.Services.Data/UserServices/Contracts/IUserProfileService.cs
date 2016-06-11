namespace EntertainmentSystem.Services.Data.UserServices.Contracts
{
    using System.IO;
    using EntertainmentSystem.Data.Models;

    public interface IUserProfileService
    {
        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <param name="userId">The id of the user to get.</param>
        /// <returns>User as queryable.</returns>
        ApplicationUser GetUserProfile(string userId);

        /// <summary>
        /// Updates the profile of the user.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        void UpdateUserProfile(ApplicationUser user);

        /// <summary>
        /// Changes the profile picture of the user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="stream">Picture file stream.</param>
        /// <param name="mimeType">Picture file mimetype.</param>
        /// <returns>The Id of the user.</returns>
        string ChangeUserPicture(string userId, Stream stream, string mimeType);
    }
}
