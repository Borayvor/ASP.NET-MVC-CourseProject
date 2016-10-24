namespace EntertainmentSystem.Services.Media.Admin
{
    using System.Linq;
    using Contracts.Media.Admin;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class AdminMediaContentService : MediaContentService, IAdminMediaContentService
    {
        public AdminMediaContentService(IDbRepository<MediaContent> contents)
            : base(contents)
        {
        }

        public IQueryable<MediaContent> GetAllWithDeleted()
        {
            return this.contents.AllWithDeleted();
        }

        public void DeletePermanent(MediaContent entity)
        {
            this.contents.DeletePermanent(entity);
            this.contents.Save();
        }
    }
}
