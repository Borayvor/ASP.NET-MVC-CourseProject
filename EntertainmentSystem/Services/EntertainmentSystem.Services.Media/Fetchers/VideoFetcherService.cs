namespace EntertainmentSystem.Services.Media.Fetchers
{
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class VideoFetcherService : BaseFetcherService, IVideoFetcherService
    {
        public VideoFetcherService(IMediaContentService contentService)
            : base(contentService)
        {
        }

        protected override ContentType GetContentType()
        {
            return ContentType.Video;
        }
    }
}
