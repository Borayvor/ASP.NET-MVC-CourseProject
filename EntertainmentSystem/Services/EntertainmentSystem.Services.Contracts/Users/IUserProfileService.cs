﻿namespace EntertainmentSystem.Services.Contracts.Users
{
    using Common;
    using Data.Models;

    public interface IUserProfileService : IBaseGetService<ApplicationUser, string>,
        IBaseUpdateService<ApplicationUser>
    {
    }
}
