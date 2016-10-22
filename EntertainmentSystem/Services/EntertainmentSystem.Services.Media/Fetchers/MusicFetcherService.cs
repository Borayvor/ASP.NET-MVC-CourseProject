namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class MusicFetcherService : IBaseMediaFetcherService
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

        public IQueryable<MediaContent> AllByTitle(string search)
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == ContentType.Music
                && c.Title.ToLower().Contains(search.ToLower()))
                .OrderByDescending(c => c.CreatedOn);
        }
    }
}
