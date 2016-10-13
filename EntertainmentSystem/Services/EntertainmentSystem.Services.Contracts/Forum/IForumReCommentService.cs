namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumReCommentService : IBaseGetService<PostReComment, Guid>, IBaseCreateService<PostReComment>,
        IBaseUpdateService<PostReComment>, IBaseDeleteService<PostReComment>
    {
    }
}
