namespace EntertainmentSystem.Services.Media.Admin
{
    using System;
    using System.Linq;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class AdminMediaContentService : IMediaAdminService<MediaContent>
    {
        protected readonly IDbRepository<MediaContent> contents;

        public AdminMediaContentService(IDbRepository<MediaContent> contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> GetAllWithDeleted()
        {
            return this.contents.AllWithDeleted();
        }

        public IQueryable<MediaContent> GetAll()
        {
            return this.contents.All();
        }

        public MediaContent GetById(Guid id)
        {
            return this.contents.GetById(id);
        }

        public void Create(MediaContent entity)
        {
            this.contents.Add(entity);
            this.contents.Save();
        }

        public void Update(MediaContent entity)
        {
            this.contents.Update(entity);
            this.contents.Save();
        }

        public void Delete(MediaContent entity)
        {
            this.contents.Delete(entity);
            this.contents.Save();
        }

        public void DeletePermanent(MediaContent entity)
        {
            this.contents.DeletePermanent(entity);
            this.contents.Save();
        }
    }
}
