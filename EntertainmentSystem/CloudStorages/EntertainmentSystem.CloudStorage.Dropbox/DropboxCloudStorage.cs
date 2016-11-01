namespace EntertainmentSystem.CloudStorage.Dropbox
{
    using System;
    using System.IO;
    using Common.ExtensionMethods;
    using Contracts;
    using DropNet;

    public class DropboxCloudStorage : ICloudStorage, IPicturesCloudStorage, IVideosCloudStorage, ISoundsCloudStorage, IUserProfilePicturesCloudStorage
    {
        private const string DropboxAppKey = "eg2iv6byv8sabfw";
        private const string DropboxAppSecret = "04ivc3lxrxfwmsc";
        private const string OauthAccessTokenValue = "4oy3copesu7oekui";
        private const string OauthAccessTokenSecret = "kvanplrc4y6xcnv";
        private const string AccessToken = "JjHLq2_mvKAAAAAAAAAA0xeOPob0f9TLSPCkjnHCH1r5R_Pm01vjcPlGJxxqoK32";

        private readonly DropNetClient client;

        public DropboxCloudStorage()
        {
            ////this.client = new DropNetClient(
            ////    DropboxAppKey,
            ////    DropboxAppSecret,
            ////    OauthAccessTokenValue,
            ////    OauthAccessTokenSecret);

            this.client = new DropNetClient(
                DropboxAppKey,
                DropboxAppSecret,
                AccessToken);
        }

        public string UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            if (stream == null || !stream.CanRead)
            {
                throw new ArgumentException("stream");
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("filename");
            }

            if (string.IsNullOrEmpty(filetype))
            {
                throw new ArgumentException("filetype");
            }

            var fullFileName = filename + filetype.GetFileExtension();

            this.client.UseSandbox = true;

            this.client.UploadFile(path, fullFileName, stream);
            var meta = client.GetMedia(fullFileName);
            return meta.Url;
        }

        public string UploadFile(byte[] bytes, string filename, string filetype, string path = "/")
        {
            if (bytes == null || bytes.Length == 0)
            {
                throw new ArgumentException("bytes");
            }

            return this.UploadFile(new MemoryStream(bytes), filename, filetype, path);
        }

        public string UploadFile(string base64, string filename, string filetype, string path = "/")
        {
            if (string.IsNullOrEmpty(base64))
            {
                throw new ArgumentException("base 64");
            }

            return this.UploadFile(Convert.FromBase64String(base64), filename, filetype, path);
        }

        public bool DeleteFile(string filename)
        {
            var meta = this.client.Delete(filename);
            return meta.Is_Deleted;
        }
    }
}
