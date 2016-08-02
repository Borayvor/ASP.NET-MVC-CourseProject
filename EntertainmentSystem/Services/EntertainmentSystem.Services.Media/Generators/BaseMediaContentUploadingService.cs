namespace EntertainmentSystem.Services.Media.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts.Media;
    using Data.Models.Media;

    public abstract class BaseMediaContentUploadingService
    {
        private readonly IMaediaContentService contents;
        private readonly IMediaCategoryService categories;
        private readonly ICloudStorage storage;

        public BaseMediaContentUploadingService(
            IMaediaContentService contents,
            IMediaCategoryService categories,
            ICloudStorage storage)
        {
            this.contents = contents;
            this.categories = categories;
            this.storage = storage;
        }

        protected ICloudStorage Storage
        {
            get { return this.storage; }
        }

        public Guid CreateContent(Stream file, ContentType type, string ownerId, string mimeType)
        {
            // TODO: refactor MediaCategoryId
            var content = new MediaContent()
            {
                ContentType = type,
                AuthorId = ownerId,
                CreatedOn = DateTime.Now,
                MediaCategoryId = this.categories.GetByName("Action").Id
            };

            content.ContentUrl = this.Storage.UploadFile(file, content.Id.ToString(), mimeType);

            this.contents.Create(content);

            return content.Id;
        }
    }
}
