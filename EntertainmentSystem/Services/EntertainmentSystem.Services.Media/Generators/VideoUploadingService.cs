namespace EntertainmentSystem.Services.Media.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts;
    using Contracts.Generators;
    using EntertainmentSystem.Data.Models.Media;

    public class VideoUploadingService : BaseMediaContentUploadingService, IVideoUploadingGeneratorService
    {
        public VideoUploadingService(
            IMaediaContentService contents,
            ICloudStorage storage)
            : base(contents, storage)
        {
        }

        public Guid Create(Stream file, string ownerId, string mimeType)
        {
            return this.CreateContent(file, ContentType.Video, ownerId, mimeType);
        }
    }
}
