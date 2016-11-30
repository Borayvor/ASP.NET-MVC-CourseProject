namespace EntertainmentSystem.Services.Media
{
    using System;
    using System.Linq;
    using Common.Enums;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class MediaCollectionService : IMediaCollectionService
    {
        protected readonly IDbRepository<MediaCollection> collections;

        public MediaCollectionService(IDbRepository<MediaCollection> collections)
        {
            this.collections = collections;
        }

        public IQueryable<MediaCollection> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn)
        {
            return this.collections.All().OrderByDescending(x => x.CreatedOn);
        }

        public MediaCollection GetById(Guid id)
        {
            return this.collections.GetById(id);
        }

        public void Create(MediaCollection entity)
        {
            this.collections.Create(entity);
            this.collections.Save();
        }

        public void Update(MediaCollection entity)
        {
            this.collections.Update(entity);
            this.collections.Save();
        }

        public void Delete(MediaCollection entity)
        {
            this.collections.Delete(entity);
            this.collections.Save();
        }
    }
}
