namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly IDbRepository<Category> categories;

        public ForumCategoryService(IDbRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public Category GetById(Guid id)
        {
            return this.categories.GetById(id);
        }

        public void Create(Category entity)
        {
            this.categories.Create(entity);
            this.categories.Save();
        }

        public void Update(Category entity)
        {
            this.categories.Update(entity);
            this.categories.Save();
        }

        public void Delete(Category entity)
        {
            this.categories.Delete(entity);
            this.categories.Save();
        }
    }
}
