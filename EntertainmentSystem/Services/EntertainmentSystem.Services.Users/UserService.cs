namespace EntertainmentSystem.Services.Users
{
    using System.Linq;
    using Contracts.Users;
    using Data.Common.Repositories;
    using Data.Models;

    public class UserService : IUserService
    {
        protected readonly IDbRepository<ApplicationUser> users;

        public UserService(IDbRepository<ApplicationUser> users)
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
    }
}
