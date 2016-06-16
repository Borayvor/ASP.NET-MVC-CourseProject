namespace EntertainmentSystem.Services.Contracts.Media.Generators
{
    using System;
    using System.IO;

    public interface IUploadingGeneratorService
    {
        /// <summary>
        /// Creates a object, by uploading it.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="ownerId">The owner of the file.</param>
        /// <param name="mimeType">The mime type of the file.</param>
        /// <returns>The id of the object.</returns>
        Guid Create(Stream file, string ownerId, string mimeType);
    }
}
