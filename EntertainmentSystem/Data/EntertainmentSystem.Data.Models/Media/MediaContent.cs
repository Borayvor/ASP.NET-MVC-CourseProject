namespace EntertainmentSystem.Data.Models.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class MediaContent : BaseModelGuid
    {
        [Required]
        [MinLength(GlobalConstants.MediaContentTitleMinLength)]
        [MaxLength(GlobalConstants.MediaContentTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(GlobalConstants.MediaContentDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [MinLength(GlobalConstants.MediaContentContentUrlMinLength)]
        [MaxLength(GlobalConstants.MediaContentContentUrlMaxLength)]
        public string ContentUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [MaxLength(GlobalConstants.MediaContentCoverImageUrlMaxLength)]
        public string CoverImageUrl { get; set; }

        public ContentType ContentType { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid MediaCategoryId { get; set; }

        public virtual MediaCategory MediaCategory { get; set; }

        public Guid? MediaCollectionId { get; set; }

        public virtual MediaCollection MediaCollection { get; set; }
    }
}
