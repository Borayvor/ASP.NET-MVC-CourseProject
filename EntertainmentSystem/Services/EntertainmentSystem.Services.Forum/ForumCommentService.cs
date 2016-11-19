namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCommentService : IForumCommentService
    {
        private readonly IDbRepository<Comment> comments;

        public ForumCommentService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments.All();
        }

        public Comment GetById(Guid id)
        {
            return this.comments.GetById(id);
        }

        public void Create(Comment entity)
        {
            this.comments.Create(entity);
            this.comments.Save();
        }

        public void Update(Comment entity)
        {
            this.comments.Update(entity);
            this.comments.Save();
        }

        public void Delete(Comment entity)
        {
            this.comments.Delete(entity);
            this.comments.Save();
        }
    }
}
