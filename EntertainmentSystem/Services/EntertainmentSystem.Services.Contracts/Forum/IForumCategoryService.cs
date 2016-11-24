namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumCategoryService : IBaseGetService<PostCategory, Guid>, IBaseCreateService<PostCategory>,
        IBaseUpdateService<PostCategory>, IBaseDeleteService<PostCategory>
    {
    }
}
