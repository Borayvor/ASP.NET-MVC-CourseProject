namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumVoteService : IBaseGetService<VotePost, int>, IBaseCreateService<VotePost>,
        IBaseUpdateService<VotePost>, IBaseDeleteService<VotePost>
    {
    }
}
