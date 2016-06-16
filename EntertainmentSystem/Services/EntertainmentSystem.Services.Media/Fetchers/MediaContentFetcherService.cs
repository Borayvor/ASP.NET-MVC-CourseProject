namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class MediaContentFetcherService : IMediaContentFetcherService
    {
        private readonly IMaediaContentService contents;

        public MediaContentFetcherService(IMaediaContentService contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> GetLast(ContentType type, int count = 5)
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == type)
                .OrderByDescending(c => c.CreatedOn)
                .Take(count);
        }
    }
}
