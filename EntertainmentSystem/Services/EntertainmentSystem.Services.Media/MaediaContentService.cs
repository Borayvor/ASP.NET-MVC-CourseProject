namespace EntertainmentSystem.Services.Media
{
    using System;
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.Media;

    public class MaediaContentService : IMaediaContentService
    {
        private readonly IDbRepository<MaediaContent> contents;

        public MaediaContentService(IDbRepository<MaediaContent> contents)
        {
            this.contents = contents;
        }

        public IQueryable<MaediaContent> GetAll()
        {
            return this.contents.All();
        }

        public MaediaContent GetById(Guid id)
        {
            return this.contents.GetById(id);
        }

        public void Create(MaediaContent content)
        {
            this.contents.Add(content);
            this.contents.Save();
        }

        public void Update(MaediaContent content)
        {
            this.contents.Update(content);
            this.contents.Save();
        }

        public void Delete(MaediaContent content)
        {
            this.contents.Delete(content);
            this.contents.Save();
        }
    }
}
