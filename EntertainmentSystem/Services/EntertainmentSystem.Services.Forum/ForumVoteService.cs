namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumVoteService : IForumVoteService
    {
        private readonly IDbRepository<VotePost> votes;

        public ForumVoteService(IDbRepository<VotePost> votes)
        {
            this.votes = votes;
        }

        public IQueryable<VotePost> GetAll()
        {
            return this.votes.All();
        }

        public VotePost GetById(int id)
        {
            return this.votes.GetById(id);
        }

        public void Create(VotePost entity)
        {
            this.votes.Create(entity);
            this.votes.Save();
        }

        public void Update(VotePost entity)
        {
            this.votes.Update(entity);
            this.votes.Save();
        }

        public void Delete(VotePost entity)
        {
            this.votes.Delete(entity);
            this.votes.Save();
        }
    }
}
