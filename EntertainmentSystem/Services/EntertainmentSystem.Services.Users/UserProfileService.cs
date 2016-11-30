namespace EntertainmentSystem.Services.Users
{
    using System.Linq;
    using Common.Enums;
    using Contracts.Users;
    using Data.Common.Repositories;
    using Data.Models;

    public class UserProfileService : IUserProfileService
    {
        protected readonly IDbRepository<ApplicationUser> users;

        public UserProfileService(IDbRepository<ApplicationUser> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn)
        {
            return this.users.All().OrderByDescending(x => x.CreatedOn);
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
    }
}
