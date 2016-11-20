namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumVoteService : IForumVoteService
    {
        private readonly IDbRepository<Vote> votes;

        public ForumVoteService(IDbRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public IQueryable<Vote> GetAll()
        {
            return this.votes.All();
        }

        public Vote GetById(int id)
        {
            return this.votes.GetById(id);
        }

        public void Create(Vote entity)
        {
            this.votes.Create(entity);
            this.votes.Save();
        }

        public void Update(Vote entity)
        {
            this.votes.Update(entity);
            this.votes.Save();
        }

        public void Delete(Vote entity)
        {
            this.votes.Delete(entity);
            this.votes.Save();
        }
    }
}
