namespace EntertainmentSystem.Services.Media.Contracts.Fetchers
{
    using System.Linq;
    using Data.Models.Media;

    public interface IMediaContentFetcherService
    {
        IQueryable<MediaContent> GetLast(ContentType type, int count = 5);
    }
}
