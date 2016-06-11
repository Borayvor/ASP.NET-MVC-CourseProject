namespace EntertainmentSystem.Services.Data.EntertainmentServices
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.Entertainment;

    public abstract class BaseUploadingGeneratorService
    {
        private readonly IDbRepository<MaediaContent> contents;
        private readonly ICloudStorage storage;

        public BaseUploadingGeneratorService(
            IDbRepository<MaediaContent> contents,
            ICloudStorage storage)
        {
            this.contents = contents;
            this.storage = storage;
        }

        protected ICloudStorage Storage
        {
            get { return this.storage; }
        }

        public Guid CreateContent(Stream file, ContentType type, string ownerId, string mimeType)
        {
            var content = new MaediaContent()
            {
                ContentType = type,
                AuthorId = ownerId
            };

            content.ContentUrl = this.Storage.UploadFile(file, content.Id.ToString(), mimeType);

            this.contents.Add(content);
            this.contents.Save();

            return content.Id;
        }
    }
}
