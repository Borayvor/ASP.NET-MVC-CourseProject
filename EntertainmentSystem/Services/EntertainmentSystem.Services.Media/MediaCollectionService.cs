namespace EntertainmentSystem.Services.Media
{
    using System.Linq;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class MediaCollectionService : IMediaCollectionService, IAdminMediaService<MediaCollection>
    {
        private readonly IDbRepository<MediaCollection> collections;

        public MediaCollectionService(IDbRepository<MediaCollection> collections)
        {
            this.collections = collections;
        }

        public IQueryable<MediaCollection> GetAll()
        {
            return this.collections.All();
        }

        public MediaCollection GetById(int id)
        {
            return this.collections.GetById(id);
        }

        public void Create(MediaCollection collection)
        {
            this.collections.Add(collection);
            this.collections.Save();
        }

        public void Update(MediaCollection collection)
        {
            this.collections.Update(collection);
            this.collections.Save();
        }

        public void Delete(MediaCollection collection)
        {
            this.collections.Delete(collection);
            this.collections.Save();
        }
    }
}
