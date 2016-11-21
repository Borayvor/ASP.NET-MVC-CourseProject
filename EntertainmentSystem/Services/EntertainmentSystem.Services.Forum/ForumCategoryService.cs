namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly IDbRepository<ForumCategory> categories;

        public ForumCategoryService(IDbRepository<ForumCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<ForumCategory> GetAll()
        {
            return this.categories.All().OrderByDescending(x => x.CreatedOn);
        }

        public ForumCategory GetById(Guid id)
        {
            return this.categories.GetById(id);
        }

        public void Create(ForumCategory entity)
        {
            this.categories.Create(entity);
            this.categories.Save();
        }

        public void Update(ForumCategory entity)
        {
            this.categories.Update(entity);
            this.categories.Save();
        }

        public void Delete(ForumCategory entity)
        {
            this.categories.Delete(entity);
            this.categories.Save();
        }
    }
}
