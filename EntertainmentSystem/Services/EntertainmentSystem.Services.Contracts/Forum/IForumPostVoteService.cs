namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumPostVoteService : IBaseGetService<PostVote, int>, IBaseCreateService<PostVote>,
        IBaseUpdateService<PostVote>, IBaseDeleteService<PostVote>
    {
    }
}
