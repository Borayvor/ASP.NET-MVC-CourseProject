﻿namespace EntertainmentSystem.Services.Media.Generators
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
            IMaediaContentService contents,
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
