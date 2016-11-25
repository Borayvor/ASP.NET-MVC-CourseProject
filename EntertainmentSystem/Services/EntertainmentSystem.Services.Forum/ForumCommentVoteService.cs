namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCommentVoteService : IForumCommentVoteService
    {
        private readonly IDbRepository<CommentVote> votes;

        public ForumCommentVoteService(IDbRepository<CommentVote> votes)
        {
            this.votes = votes;
        }

        public IQueryable<CommentVote> GetAll()
        {
            return this.votes.All().OrderByDescending(x => x.CreatedOn);
        }

        public CommentVote GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(CommentVote entity)
        {
            this.votes.Create(entity);
            this.votes.Save();
        }

        public void Update(CommentVote entity)
        {
            this.votes.Update(entity);
            this.votes.Save();
        }

        public void Delete(CommentVote entity)
        {
            this.votes.Delete(entity);
            this.votes.Save();
        }
    }
}
