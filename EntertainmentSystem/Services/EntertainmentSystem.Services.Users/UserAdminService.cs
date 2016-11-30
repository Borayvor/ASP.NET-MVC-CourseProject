namespace EntertainmentSystem.Services.Users
{
    using System.Linq;
    using Contracts.Users;
    using Data.Common.Repositories;
    using Data.Models;

    public class UserAdminService : UserModeratorService, IUserAdminService
    {
        public UserAdminService(IDbRepository<ApplicationUser> users)
            : base(users)
        {
        }

        public IQueryable<ApplicationUser> GetAllWithDeleted()
        {
            return this.users.AllWithDeleted();
        }

        public void DeletePermanent(ApplicationUser user)
        {
            this.users.DeletePermanent(user);
            this.users.Save();
        }
    }
}
