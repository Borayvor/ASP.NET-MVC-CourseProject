namespace EntertainmentSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ValidatePictureFileAttribute : BaseValidateMediaFileAttribute
    {
        private readonly IList<string> allowedMimeTypes = new List<string>() { "image/jpeg", "image/png" };

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

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (this.IsValid(value))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(this.ErrorMessage);
        }
    }
}
