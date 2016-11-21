namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumPostService : IForumPostService
    {
        private readonly IDbRepository<Post> posts;

        public ForumPostService(IDbRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts.All().OrderByDescending(x => x.CreatedOn);
        }

        public Post GetById(Guid id)
        {
            return this.posts.GetById(id);
        }

        public void Create(Post entity)
        {
            this.posts.Create(entity);
            this.posts.Save();
        }

        public void Update(Post entity)
        {
            this.posts.Update(entity);
            this.posts.Save();
        }

        public void Delete(Post entity)
        {
            this.posts.Delete(entity);
            this.posts.Save();
        }
    }
}
