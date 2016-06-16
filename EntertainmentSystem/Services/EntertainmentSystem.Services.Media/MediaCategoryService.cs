namespace EntertainmentSystem.Services.Media
{
    using System.Linq;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

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

        public MediaCategory GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public MediaCategory GetByName(string name)
        {
            return this.categories.All().FirstOrDefault(x => x.Name == name);
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
