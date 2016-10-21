namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System;
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class MusicFetcherService : IMusicFetcherService
    {
        private readonly IMaediaContentService contents;

        public MusicFetcherService(IMaediaContentService contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> All()
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == ContentType.Music);
        }

        public IQueryable<MediaContent> SearchByTitle(string search)
        {
            throw new NotImplementedException();
        }
    }
}
