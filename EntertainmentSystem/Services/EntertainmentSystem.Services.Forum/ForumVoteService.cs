namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumVoteService : IForumVoteService
    {
        private readonly IDbRepository<PostVote> votes;

        public ForumVoteService(IDbRepository<PostVote> votes)
        {
            this.votes = votes;
        }

        public IQueryable<PostVote> GetAll()
        {
            return this.votes.All();
        }

        public PostVote GetById(int id)
        {
            return this.votes.GetById(id);
        }

        public void Create(PostVote entity)
        {
            this.votes.Create(entity);
            this.votes.Save();
        }

        public void Update(PostVote entity)
        {
            this.votes.Update(entity);
            this.votes.Save();
        }

        public void Delete(PostVote entity)
        {
            this.votes.Delete(entity);
            this.votes.Save();
        }
    }
}
