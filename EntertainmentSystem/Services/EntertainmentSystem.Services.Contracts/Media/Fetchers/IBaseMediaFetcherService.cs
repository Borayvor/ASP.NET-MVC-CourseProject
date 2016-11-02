namespace EntertainmentSystem.Services.Contracts.Media.Fetchers
{
    using System;
    using System.Linq;
    using Data.Models.Media;
    using EntertainmentSystem.Common.Constants;

    public interface IBaseMediaFetcherService
    {
        IQueryable<MediaContent> All(string title = GlobalConstants.StringEmpty);

        MediaContent GetById(Guid id);
    }
}
