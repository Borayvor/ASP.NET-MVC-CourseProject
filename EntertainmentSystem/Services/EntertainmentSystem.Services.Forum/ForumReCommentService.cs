namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumReCommentService : IForumReCommentService
    {
        private readonly IDbRepository<PostReComment> reComments;

        public ForumReCommentService(IDbRepository<PostReComment> reComments)
        {
            this.reComments = reComments;
        }

        public IQueryable<PostReComment> GetAll()
        {
            return this.reComments.All();
        }

        public PostReComment GetById(Guid id)
        {
            return this.reComments.GetById(id);
        }

        public void Create(PostReComment entity)
        {
            this.reComments.Create(entity);
            this.reComments.Save();
        }

        public void Update(PostReComment entity)
        {
            this.reComments.Update(entity);
            this.reComments.Save();
        }

        public void Delete(PostReComment entity)
        {
            this.reComments.Delete(entity);
            this.reComments.Save();
        }
    }
}
