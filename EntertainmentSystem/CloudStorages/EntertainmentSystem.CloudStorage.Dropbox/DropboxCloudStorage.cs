namespace EntertainmentSystem.CloudStorage.Dropbox
{
    using System;
    using System.IO;
    using Common.ExtensionMethods;
    using Common.Validators;
    using Contracts;
    using DropNet;

    public class DropboxCloudStorage :
        ICloudStorage, IPicturesCloudStorage,
        IVideosCloudStorage, ISoundsCloudStorage, IUserProfilePicturesCloudStorage
    {
        private const string DropboxAppKey = "eg2iv6byv8sabfw";
        private const string DropboxAppSecret = "04ivc3lxrxfwmsc";
        private const string OauthAccessTokenValue = "4oy3copesu7oekui";
        private const string OauthAccessTokenSecret = "kvanplrc4y6xcnv";

        private readonly DropNetClient client;

        public DropboxCloudStorage()
        {
            this.client = new DropNetClient(
                DropboxAppKey,
                DropboxAppSecret,
                OauthAccessTokenValue,
                OauthAccessTokenSecret);
        }

        public string UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            var fullFileName = filename + filetype.GetFileExtension();

            this.client.UseSandbox = true;

            this.client.UploadFile(path, fullFileName, stream);
            var meta = client.GetMedia(fullFileName);
            return meta.Url;
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
            var meta = this.client.Delete(filename);
            return meta.Is_Deleted;
        }
    }
}
