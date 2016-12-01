namespace EntertainmentSystem.Web.Infrastructure.Filters
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidatePostTagsCountAttribute : ValidationAttribute
    {
        private const int DefaultMinTagsCount = 1;

        private int minTagsCount;

        public ValidatePostTagsCountAttribute()
        {
            this.minTagsCount = DefaultMinTagsCount;
        }

        public ValidatePostTagsCountAttribute(int tagsCount)
        {
            this.minTagsCount = tagsCount;
        }

        public override bool IsValid(object value)
        {
            try
            {
                this.Validate(value);
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

        private void Validate(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(string.Format("Tags count must be {0} or more !", this.minTagsCount));
            }

            var tagsAsString = value as string;
            var tagsArray = tagsAsString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            if (tagsArray.Length < this.minTagsCount)
            {
                throw new ValidationException(string.Format("Tags count must be {0} or more !", this.minTagsCount));
            }
        }
    }
}
