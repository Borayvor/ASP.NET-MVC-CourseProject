namespace EntertainmentSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;

    public class ValidateMusicFileAttribute : BaseValidateMediaFileAttribute
    {
        private readonly IList<string> allowedMimeTypes = new List<string>() { "audio/mpeg", "audio/wav", "audio/mp3" };

        public override bool IsValid(object value)
        {
            try
            {
                this.ValidateOrThrowException(value, 1024 * 1024 * 3 /* 3 MB*/, this.allowedMimeTypes);
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
