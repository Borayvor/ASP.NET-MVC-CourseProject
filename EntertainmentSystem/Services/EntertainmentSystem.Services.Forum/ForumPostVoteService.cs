namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Common.Enums;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumPostVoteService : IForumPostVoteService
    {
        private readonly IDbRepository<PostVote> votes;

        public ForumPostVoteService(IDbRepository<PostVote> votes)
        {
            this.votes = votes;
        }

        public IQueryable<PostVote> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn)
        {
            return this.votes.All().OrderByDescending(x => x.CreatedOn);
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
