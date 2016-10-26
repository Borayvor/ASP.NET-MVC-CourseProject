namespace EntertainmentSystem.Services.Media.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts.Media;
    using Contracts.Media.Generators;
    using Data.Models.Media;

    public class PictureUploadingService : BaseMediaContentUploadingService, IPictureUploadingGeneratorService
    {
        public PictureUploadingService(
            IMediaContentService contents,
            ICloudStorage storage)
            : base(contents, storage)
        {
        }

        public Guid Create(
            Stream file,
            string mimeType,
            string ownerId,
            string title,
            string description,
            Guid categoryId,
            Guid? collectionId)
        {
            return this.CreateContent(
                file,
                mimeType,
                ownerId,
                title,
                description,
                categoryId,
                collectionId,
                ContentType.Picture);
        }
    }
}
