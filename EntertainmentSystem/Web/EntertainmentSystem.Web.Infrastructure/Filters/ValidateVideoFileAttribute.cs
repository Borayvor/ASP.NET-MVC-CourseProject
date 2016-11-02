namespace EntertainmentSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;

    public class ValidateVideoFileAttribute : BaseValidateMediaFileAttribute
    {
        private readonly IList<string> allowedMimeTypes = new List<string>() { "video/webm", "video/mp4" };

        public override bool IsValid(object value)
        {
            try
            {
                this.ValidateOrThrowException(value, 1024 * 1024 * 35 /* 35 MB*/, this.allowedMimeTypes);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }

            return true;
        }
    }
}
