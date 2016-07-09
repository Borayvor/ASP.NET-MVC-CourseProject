namespace EntertainmentSystem.Services.Media.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts.Media;
    using Contracts.Media.Generators;
    using Data.Models.Media;

    public class VideoUploadingService : BaseMediaContentUploadingService, IVideoUploadingGeneratorService
    {
        public VideoUploadingService(
            IMaediaContentService contents,
            IMediaCategoryService categories,
            ICloudStorage storage)
            : base(contents, categories, storage)
        {
        }

        public Guid Create(Stream file, string ownerId, string mimeType)
        {
            return this.CreateContent(file, ContentType.Video, ownerId, mimeType);
        }
    }
}
