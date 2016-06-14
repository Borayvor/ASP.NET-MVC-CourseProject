namespace EntertainmentSystem.Services.Data.MediaServices.Generators
{
    using System;
    using System.IO;
    using CloudStorage.Contracts;
    using Contracts.Generators;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.Media;

    public class PictureUploadingGeneratorService : BaseUploadingGeneratorService, IPictureUploadingGeneratorService
    {
        public PictureUploadingGeneratorService(
            IDbRepository<MaediaContent> contents,
            ICloudStorage storage)
            : base(contents, storage)
        {
        }

        public Guid Create(Stream file, string ownerId, string mimeType)
        {
            return this.CreateContent(file, ContentType.Picture, ownerId, mimeType);
        }
    }
}
