namespace EntertainmentSystem.Services.Media.Fetchers
{
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class MusicFetcherService : BaseFetcherService, IMusicFetcherService
    {
        public MusicFetcherService(IMaediaContentService contentService)
            : base(contentService)
        {
        }

        protected override ContentType GetContentType()
        {
            return ContentType.Music;
        }
    }
}
