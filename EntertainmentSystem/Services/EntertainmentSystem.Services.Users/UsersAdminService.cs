namespace EntertainmentSystem.Services.Users
{
    using System.Linq;
    using Contracts.Users;
    using Data.Common.Repositories;
    using Data.Models;

    public class UsersAdminService : IUserAdminService
    {
        protected readonly IDbRepository<ApplicationUser> users;

        public UsersAdminService(IDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<ApplicationUser> GetAllWithDeleted()
        {
            return this.users.AllWithDeleted();
        }

        public ApplicationUser GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public void Delete(ApplicationUser user)
        {
            this.users.Delete(user);
            this.users.Save();
        }

        public void DeletePermanent(ApplicationUser user)
        {
            this.users.DeletePermanent(user);
            this.users.Save();
        }
    }
}
