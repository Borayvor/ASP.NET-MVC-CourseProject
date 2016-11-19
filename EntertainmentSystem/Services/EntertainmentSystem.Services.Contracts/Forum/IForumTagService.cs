namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumTagService : IBaseGetService<Tag, int>, IBaseCreateService<Tag>,
        IBaseUpdateService<Tag>, IBaseDeleteService<Tag>
    {
    }
}
