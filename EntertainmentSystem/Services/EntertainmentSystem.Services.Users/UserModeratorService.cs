namespace EntertainmentSystem.Services.Users
{
    using System.Linq;
    using Contracts.Users;
    using Data.Common.Repositories;
    using Data.Models;

    public class UserModeratorService : IUserModeratorService
    {
        protected readonly IDbRepository<ApplicationUser> users;

        public UserModeratorService(IDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All();
        }

        public ApplicationUser GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public void Update(ApplicationUser user)
        {
            this.users.Update(user);
            this.users.Save();
        }

        public void Delete(ApplicationUser user)
        {
            this.users.Delete(user);
            this.users.Save();
        }
    }
}
