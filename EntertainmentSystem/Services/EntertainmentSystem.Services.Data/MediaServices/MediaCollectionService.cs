namespace EntertainmentSystem.Services.Data.MediaServices
{
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.Media;

    public class MediaCollectionService : IMediaCollectionService
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
