namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumTagService : IForumTagService
    {
        private readonly IDbRepository<Tag> tags;

        public ForumTagService(IDbRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> GetAll()
        {
            return this.tags.All();
        }

        public Tag GetById(int id)
        {
            return this.tags.GetById(id);
        }

        public void Create(Tag entity)
        {
            this.tags.Create(entity);
            this.tags.Save();
        }

        public void Update(Tag entity)
        {
            this.tags.Update(entity);
            this.tags.Save();
        }

        public void Delete(Tag entity)
        {
            this.tags.Delete(entity);
            this.tags.Save();
        }
    }
}
