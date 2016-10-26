namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public abstract class BaseFetcherService : IBaseMediaFetcherService
    {
        private readonly IMediaContentService contentService;
        private readonly ContentType type;

        public BaseFetcherService(IMediaContentService contentService)
        {
            this.contentService = contentService;
            this.type = this.GetContentType();
        }

        public IQueryable<MediaContent> All()
        {
            return this.contentService.GetAll()
                .Where(c => c.ContentType == this.type)
                .OrderByDescending(x => x.CreatedOn);
        }

        public IQueryable<MediaContent> AllByTitle(string search)
        {
            return this.contentService
                .GetAll()
                .Where(c => c.ContentType == this.type
                && c.Title.ToLower().Contains(search.ToLower()))
                .OrderByDescending(c => c.CreatedOn);
        }

        protected abstract ContentType GetContentType();
    }
}
