namespace EntertainmentSystem.Services.Media.Fetchers
{
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class PictureFetcherService : BaseFetcherService, IPictureFetcherService
    {
        public PictureFetcherService(IMaediaContentService contentService)
            : base(contentService)
        {
        }

        protected override ContentType GetContentType()
        {
            return ContentType.Picture;
        }
    }
}
