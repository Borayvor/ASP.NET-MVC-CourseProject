namespace EntertainmentSystem.Services.Contracts.Forum
{
    using Common;
    using Data.Models.Forum;

    public interface IForumTagService : IBaseGetService<PostTag, int>, IBaseCreateService<PostTag>,
        IBaseUpdateService<PostTag>, IBaseDeleteService<PostTag>
    {
    }
}
