namespace EntertainmentSystem.Services.Media.Admin
{
    using System.Linq;
    using Contracts.Media.Admin;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class AdminMediaCategoryService : MediaCategoryService, IAdminMediaCategoryService
    {
        public AdminMediaCategoryService(IDbRepository<MediaCategory> categories)
            : base(categories)
        {
        }

        public IQueryable<MediaCategory> GetAllWithDeleted()
        {
            return this.categories.AllWithDeleted();
        }

        public void DeletePermanent(MediaCategory entity)
        {
            this.categories.DeletePermanent(entity);
            this.categories.Save();
        }
    }
}
