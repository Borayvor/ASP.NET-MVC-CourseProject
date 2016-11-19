namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumCategoryService : IBaseGetService<ForumCategory, Guid>, IBaseCreateService<ForumCategory>,
        IBaseUpdateService<ForumCategory>, IBaseDeleteService<ForumCategory>
    {
    }
}
