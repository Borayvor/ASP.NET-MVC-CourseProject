namespace EntertainmentSystem.Services.Media
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class MediaContentService : IMaediaContentService
    {
        private readonly IDbRepository<MediaContent> contents;

        public MediaContentService(IDbRepository<MediaContent> contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> GetAll()
        {
            return this.contents.All();
        }

        public MediaContent GetById(Guid id)
        {
            return this.contents.GetById(id);
        }

        public void Create(MediaContent content)
        {
            this.contents.Add(content);
            this.contents.Save();
        }

        public void Update(MediaContent content)
        {
            this.contents.Update(content);
            this.contents.Save();
        }

        public void Delete(MediaContent content)
        {
            this.contents.Delete(content);
            this.contents.Save();
        }
    }
}
