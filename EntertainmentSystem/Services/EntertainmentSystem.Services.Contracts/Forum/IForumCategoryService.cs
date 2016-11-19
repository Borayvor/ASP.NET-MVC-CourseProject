namespace EntertainmentSystem.Services.Contracts.Forum
{
    using System;
    using Common;
    using Data.Models.Forum;

    public interface IForumCategoryService : IBaseGetService<Category, Guid>, IBaseCreateService<Category>,
        IBaseUpdateService<Category>, IBaseDeleteService<Category>
    {
    }
}
