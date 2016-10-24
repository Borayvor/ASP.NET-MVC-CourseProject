namespace EntertainmentSystem.Services.Contracts.Media
{
    using System;
    using Common;
    using Data.Models.Media;

    public interface IMediaContentService : IBaseGetService<MediaContent, Guid>,
        IBaseCreateService<MediaContent>, IBaseUpdateService<MediaContent>,
        IBaseDeleteService<MediaContent>
    {
    }
}
