namespace EntertainmentSystem.Services.Contracts.Media
{
    using Common;
    using Data.Models.Media;

    public interface IMaediaContentService : IBaseGetService<MediaContent>,
        IBaseCreateService<MediaContent>, IBaseUpdateService<MediaContent>,
        IBaseDeleteService<MediaContent>
    {
    }
}
