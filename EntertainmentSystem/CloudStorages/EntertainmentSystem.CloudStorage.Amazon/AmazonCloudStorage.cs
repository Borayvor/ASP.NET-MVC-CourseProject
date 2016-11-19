namespace EntertainmentSystem.CloudStorage.Amazon
{
    using System;
    using System.IO;
    using Common.Validators;
    using Contracts;

    public class AmazonCloudStorage :
        ICloudStorage, IPicturesCloudStorage,
        IVideosCloudStorage, ISoundsCloudStorage, IUserProfilePicturesCloudStorage
    {
        public string UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            throw new NotImplementedException();
        }

        public string UploadFile(byte[] bytes, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateByteArray(bytes);

            return this.UploadFile(new MemoryStream(bytes), filename, filetype, path);
        }

        public string UploadFile(string base64, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateBase64(base64);

            return this.UploadFile(Convert.FromBase64String(base64), filename, filetype, path);
        }

        public bool DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
