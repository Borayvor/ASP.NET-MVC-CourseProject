namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumCommentService : IBaseGetService<Comment, Guid>, IBaseCreateService<Comment>,
        IBaseUpdateService<Comment>, IBaseDeleteService<Comment>
    {
    }
}
