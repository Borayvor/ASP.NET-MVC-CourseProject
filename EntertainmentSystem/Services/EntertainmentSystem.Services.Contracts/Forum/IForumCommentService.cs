namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumCommentService : IBaseGetService<PostComment, Guid>, IBaseCreateService<PostComment>,
        IBaseUpdateService<PostComment>, IBaseDeleteService<PostComment>
    {
    }
}
