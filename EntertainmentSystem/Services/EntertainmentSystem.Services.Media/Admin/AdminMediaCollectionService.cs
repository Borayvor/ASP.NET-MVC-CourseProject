namespace EntertainmentSystem.Services.Media.Admin
{
    using System.Linq;
    using Contracts.Media.Admin;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class AdminMediaCollectionService : MediaCollectionService, IAdminMediaCollectionService
    {
        public AdminMediaCollectionService(IDbRepository<MediaCollection> collections)
            : base(collections)
        {
        }

        public IQueryable<MediaCollection> GetAllWithDeleted()
        {
            return this.collections.AllWithDeleted().OrderByDescending(x => x.CreatedOn);
        }

        public void DeletePermanent(MediaCollection entity)
        {
            this.collections.DeletePermanent(entity);
            this.collections.Save();
        }
    }
}
