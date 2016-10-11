namespace EntertainmentSystem.Services.Media
{
    using System;
    using System.Linq;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class MediaContentService : IMaediaContentService
    {
        protected readonly IDbRepository<MediaContent> contents;

        public MediaContentService(IDbRepository<MediaContent> contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> GetAll()
        {
            return this.contents.All();
        }

        public MediaContent GetById(object id)
        {
            var guidId = (Guid)id;

            return this.contents.GetById(guidId);
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
    }
}
