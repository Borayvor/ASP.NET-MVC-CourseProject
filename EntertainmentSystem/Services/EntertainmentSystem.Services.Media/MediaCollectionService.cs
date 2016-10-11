namespace EntertainmentSystem.Services.Media
{
    using System.Linq;
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

        public IQueryable<MediaCollection> GetAll()
        {
            return this.collections.All();
        }

        public MediaCollection GetById(object id)
        {
            var intId = (int)id;

            return this.collections.GetById(intId);
        }

        public void Create(MediaCollection entity)
        {
            this.collections.Add(entity);
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
