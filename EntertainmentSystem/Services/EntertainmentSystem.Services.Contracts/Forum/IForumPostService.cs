namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumPostService : IBaseGetService<Post, Guid>, IBaseCreateService<Post>,
        IBaseUpdateService<Post>, IBaseDeleteService<Post>
    {

    }
}
