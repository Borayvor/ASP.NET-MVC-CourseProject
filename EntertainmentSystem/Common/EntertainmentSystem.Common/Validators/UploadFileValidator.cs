namespace EntertainmentSystem.Common.Validators
{
    using System;
    using System.IO;

    public class UploadFileValidator
    {
        public static void ValidateStream(Stream stream)
        {
            if (stream == null || !stream.CanRead)
            {
                throw new ArgumentException("stream");
            }
        }

        public static void ValidateFileName(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("filename");
            }
        }

        public static void ValidateFileType(string filetype)
        {
            if (string.IsNullOrEmpty(filetype))
            {
                throw new ArgumentException("filetype");
            }
        }

        public static void ValidateByteArray(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                throw new ArgumentException("bytes");
            }
        }

        public static void ValidateBase64(string base64)
        {
            if (string.IsNullOrEmpty(base64))
            {
                throw new ArgumentException("base 64");
            }
        }
    }
}
