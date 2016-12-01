namespace EntertainmentSystem.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string GetContentType(this string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return string.Empty;
            }

            var extensionIndex = filename.LastIndexOf(".");

            if (extensionIndex < 0 || extensionIndex == filename.Length - 1)
            {
                return string.Empty;
            }

            var extension = filename.Substring(extensionIndex + 1);

            switch (extension)
            {
                case "jpg": return "image/jpeg";
                case "jpeg": return "image/jpeg";
                case "png": return "image/png";
                case "webm": return "video/webm";
                case "mp4": return "video/mp4";
                case "wav": return "audio/wav";
                case "mp3": return "audio/mp3";
                case "mpeg": return "audio/mpeg";
                default: return string.Empty;
            }
        }

        public static string GetFileExtension(this string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return string.Empty;
            }

            switch (contentType)
            {
                case "image/jpeg": return ".jpg";
                case "image/png": return ".png";
                case "video/webm": return ".webm";
                case "video/mp4": return ".mp4";
                case "audio/wav": return ".wav";
                case "audio/mp3": return ".mp3";
                case "audio/mpeg": return ".mpeg";
                default: return string.Empty;
            }
        }
    }
}
