namespace EntertainmentSystem.Services.Contracts.Media
{
    using System;
    using Common;
    using Data.Models.Media;

    public interface IMediaCollectionService : IBaseGetService<MediaCollection, Guid>,
        IBaseCreateService<MediaCollection>, IBaseUpdateService<MediaCollection>,
        IBaseDeleteService<MediaCollection>
    {
    }
}
