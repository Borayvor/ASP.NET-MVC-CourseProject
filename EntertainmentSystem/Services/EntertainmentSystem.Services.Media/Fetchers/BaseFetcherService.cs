namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public abstract class BaseFetcherService : IBaseMediaFetcherService
    {
        private readonly IMaediaContentService contentService;
        protected readonly ContentType type;

        public BaseFetcherService(IMaediaContentService contentService)
        {
            this.contentService = contentService;
        }

        public IQueryable<MediaContent> All()
        {
            return this.contentService.GetAll()
                .Where(c => c.ContentType == this.type);
        }

        public IQueryable<MediaContent> AllByTitle(string search)
        {
            return this.contentService
                .GetAll()
                .Where(c => c.ContentType == this.type
                && c.Title.ToLower().Contains(search.ToLower()))
                .OrderByDescending(c => c.CreatedOn);
        }
    }
}
