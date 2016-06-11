namespace EntertainmentSystem.Services.Data.EntertainmentServices
{
    using System;
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.Entertainment;

    public class MediaCategoryService : IMediaCategoryService
    {
        private readonly IDbRepository<MediaCategory> categories;

        public MediaCategoryService(IDbRepository<MediaCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<MediaCategory> GetAll()
        {
            return this.categories.All();
        }

        public MediaCategory GetById(Guid id)
        {
            return this.categories.GetById(id);
        }

        public void Create(MediaCategory category)
        {
            this.categories.Add(category);
            this.categories.Save();
        }

        public void Update(MediaCategory category)
        {
            this.categories.Update(category);
            this.categories.Save();
        }

        public void Delete(MediaCategory category)
        {
            this.categories.Delete(category);
            this.categories.Save();
        }
    }
}
