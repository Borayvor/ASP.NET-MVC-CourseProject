namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCommentService : IForumCommentService
    {
        private readonly IDbRepository<PostComment> comments;

        public ForumCommentService(IDbRepository<PostComment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<PostComment> GetAll()
        {
            return this.comments.All();
        }

        public PostComment GetById(Guid id)
        {
            return this.comments.GetById(id);
        }

        public void Create(PostComment entity)
        {
            this.comments.Create(entity);
            this.comments.Save();
        }

        public void Update(PostComment entity)
        {
            this.comments.Update(entity);
            this.comments.Save();
        }

        public void Delete(PostComment entity)
        {
            this.comments.Delete(entity);
            this.comments.Save();
        }
    }
}
