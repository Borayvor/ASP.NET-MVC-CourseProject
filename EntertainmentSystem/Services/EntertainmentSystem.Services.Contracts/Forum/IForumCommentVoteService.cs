namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumCommentVoteService : IBaseGetService<CommentVote, int>,
        IBaseCreateService<CommentVote>, IBaseUpdateService<CommentVote>, IBaseDeleteService<CommentVote>
    {
    }
}
