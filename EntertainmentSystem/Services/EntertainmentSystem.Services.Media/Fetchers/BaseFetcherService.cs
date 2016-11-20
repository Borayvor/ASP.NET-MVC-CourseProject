namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System;
    using System.Linq;
    using Common.Constants;
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

        public IQueryable<MediaContent> GetAll(string title = GlobalConstants.StringEmpty)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return this.contentService.GetAll()
                .Where(c => c.ContentType == this.type)
                .OrderByDescending(x => x.CreatedOn);
            }
            else
            {
                return this.contentService
                .GetAll()
                .Where(c => c.ContentType == this.type
                && c.Title.ToLower().Contains(title.ToLower()))
                .OrderByDescending(c => c.CreatedOn);
            }

        }

        public MediaContent GetById(Guid id)
        {
            return this.contentService.GetById(id);
        }

        protected abstract ContentType GetContentType();
    }
}
