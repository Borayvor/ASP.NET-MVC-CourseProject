namespace EntertainmentSystem.Services.Contracts.Media.Fetchers
{
    using System.Linq;
    using Common.Constants;
    using Data.Models.Media;

    public interface IMediaContentFetcherService
    {
        IQueryable<MediaContent> GetLast(ContentType type, int count = GlobalConstants.HomeLastContentCount);
    }
}
