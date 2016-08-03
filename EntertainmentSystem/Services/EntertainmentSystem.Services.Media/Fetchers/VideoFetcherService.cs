namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System;
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

        public IQueryable<MediaContent> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
