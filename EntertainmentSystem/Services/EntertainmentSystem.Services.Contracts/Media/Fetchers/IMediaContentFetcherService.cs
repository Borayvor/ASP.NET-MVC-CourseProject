namespace EntertainmentSystem.Services.Contracts.Media.Fetchers
{
    using System.Linq;
    using Data.Models.Media;
    using EntertainmentSystem.Common.Constants;

    public interface IMediaContentFetcherService
    {
        IQueryable<MediaContent> GetLast(ContentType type, int count = GlobalConstants.HomeLastContentCount);
    }
}
