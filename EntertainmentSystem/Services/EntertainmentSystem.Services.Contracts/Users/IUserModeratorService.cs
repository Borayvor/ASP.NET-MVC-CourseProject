namespace EntertainmentSystem.Services.Contracts.Users
{
    using Common;
    using Data.Models;

    public interface IUserModeratorService : IBaseGetService<ApplicationUser, string>,
        IBaseDeleteService<ApplicationUser>
    {
    }
}
