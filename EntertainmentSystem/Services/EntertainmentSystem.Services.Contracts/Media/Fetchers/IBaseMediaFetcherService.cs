namespace EntertainmentSystem.Services.Contracts.Media.Fetchers
{
    using System;
    using System.Linq;
    using Data.Models.Media;

    public interface IBaseMediaFetcherService
    {
        IQueryable<MediaContent> All(string title);

        MediaContent GetById(Guid id);
    }
}
