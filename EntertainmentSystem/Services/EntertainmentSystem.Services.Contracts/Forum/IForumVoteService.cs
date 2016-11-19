namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumVoteService : IBaseGetService<Vote, int>, IBaseCreateService<Vote>,
        IBaseUpdateService<Vote>, IBaseDeleteService<Vote>
    {
    }
}
