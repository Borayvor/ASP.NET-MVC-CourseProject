namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class VideoFetcherService : IVideoFetcherService
    {
        private readonly IMaediaContentService contents;

        public VideoFetcherService(IMaediaContentService contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> All()
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == ContentType.Video);
        }

        public IQueryable<MediaContent> AllByTitle(string search)
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == ContentType.Video
                && c.Title.ToLower().Contains(search.ToLower()))
                .OrderByDescending(c => c.CreatedOn);
        }
    }
}
