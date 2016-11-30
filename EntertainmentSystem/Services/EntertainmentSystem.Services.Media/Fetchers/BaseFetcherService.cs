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

        public IQueryable<MediaContent> GetAll(
            string title = GlobalConstants.StringEmpty,
            string collectionName = GlobalConstants.StringEmpty,
            string categoryName = GlobalConstants.StringEmpty)
        {
            var content = this.contentService.GetAll()
                .Where(c => c.ContentType == this.type);

            if (!string.IsNullOrWhiteSpace(title))
            {
                content = content.Where(c => c.Title.ToLower().Contains(title.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(collectionName))
            {
                content = content.Where(c => c.MediaCollection.Name == collectionName);
            }
            else
            {
                content = content.Where(c => c.MediaCollection.Name != collectionName);
            }

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                content = content.Where(c => c.MediaCategory.Name == categoryName);
            }
            else
            {
                content = content.Where(c => c.MediaCategory.Name != categoryName);
            }

            return content.OrderByDescending(c => c.CreatedOn);
        }

        public MediaContent GetById(Guid id)
        {
            return this.contentService.GetById(id);
        }

        protected abstract ContentType GetContentType();
    }
}
