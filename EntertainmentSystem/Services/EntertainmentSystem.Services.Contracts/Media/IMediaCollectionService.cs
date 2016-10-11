namespace EntertainmentSystem.Services.Contracts.Media
{
    using Common;
    using Data.Models.Media;

    public interface IMediaCollectionService : IBaseGetService<MediaCollection>,
        IBaseCreateService<MediaCollection>, IBaseUpdateService<MediaCollection>,
        IBaseDeleteService<MediaCollection>
    {
    }
}
