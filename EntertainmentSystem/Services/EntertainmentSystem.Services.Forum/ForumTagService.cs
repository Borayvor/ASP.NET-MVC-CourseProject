namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumTagService : IForumTagService
    {
        private readonly IDbRepository<PostTag> tags;

        public ForumTagService(IDbRepository<PostTag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<PostTag> GetAll()
        {
            return this.tags.All();
        }

        public PostTag GetById(int id)
        {
            return this.tags.GetById(id);
        }

        public void Create(PostTag entity)
        {
            this.tags.Create(entity);
            this.tags.Save();
        }

        public void Update(PostTag entity)
        {
            this.tags.Update(entity);
            this.tags.Save();
        }

        public void Delete(PostTag entity)
        {
            this.tags.Delete(entity);
            this.tags.Save();
        }
    }
}
