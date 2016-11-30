namespace EntertainmentSystem.Web.Infrastructure.Filters
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public abstract class BaseValidateMediaFileAttribute : ValidationAttribute
    {
        private const int MbSizeAsBytes = 1024 * 1024;

        protected void ValidateOrThrowException(object value, int allowedMaxSize, IList<string> allowedMimeTypes)
        {
            var fileAsHttpPostedFileBase = value as HttpPostedFileBase;

            if (fileAsHttpPostedFileBase == null)
            {
                throw new ValidationException("Please upload a file !");
            }

            if (fileAsHttpPostedFileBase.ContentLength == 0)
            {
                throw new ValidationException("Please upload a non-empty file !");
            }

            if (fileAsHttpPostedFileBase.ContentLength > allowedMaxSize)
            {
                throw new ValidationException(string.Format("File size can not exceed {0} mb !", allowedMaxSize / MbSizeAsBytes));
            }

            if (!allowedMimeTypes.Contains(fileAsHttpPostedFileBase.ContentType))
            {
                throw new ValidationException("File type not supported !");
            }
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
