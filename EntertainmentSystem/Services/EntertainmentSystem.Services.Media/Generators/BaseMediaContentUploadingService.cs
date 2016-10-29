namespace EntertainmentSystem.Services.Media.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts.Media;
    using Data.Models.Media;

    public abstract class BaseMediaContentUploadingService
    {
        private readonly IMediaContentService contents;
        private readonly ICloudStorage storage;

        public BaseMediaContentUploadingService(
            IMediaContentService contents,
            ICloudStorage storage)
        {
            this.contents = contents;
            this.storage = storage;
        }

        protected ICloudStorage Storage
        {
            get { return this.storage; }
        }

        public Guid CreateContent(
            Stream file,
            string mimeType,
            string ownerId,
            string title,
            string description,
            string coverImageUrl,
            Guid categoryId,
            Guid? collectionId,
            ContentType type)
        {
            var content = new MediaContent()
            {
                ContentType = type,
                AuthorId = ownerId,
                Title = title,
                Description = description,
                CoverImageUrl = coverImageUrl,
                MediaCategoryId = categoryId,
                MediaCollectionId = collectionId
            };

            content.ContentUrl = this.Storage.UploadFile(file, content.Id.ToString(), mimeType);
            content.CoverImageUrl = "";

            this.contents.Create(content);

            return content.Id;
        }
    }
}
