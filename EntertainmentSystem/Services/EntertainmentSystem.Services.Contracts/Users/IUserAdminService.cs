namespace EntertainmentSystem.Services.Contracts.Users
{
    using Common;
    using Data.Models;

    public interface IUserAdminService : IBaseGetService<ApplicationUser, string>,
        IBaseUpdateService<ApplicationUser>, IBaseDeleteService<ApplicationUser>,
        IBaseAdminService<ApplicationUser>
    {
    }
}
