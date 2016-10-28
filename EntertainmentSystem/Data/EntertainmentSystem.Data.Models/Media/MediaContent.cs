namespace EntertainmentSystem.Data.Models.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class MediaContent : BaseModelGuid
    {
        [Required]
        [MinLength(1)]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1024)]
        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid MediaCategoryId { get; set; }

        public virtual MediaCategory MediaCategory { get; set; }

        public Guid? MediaCollectionId { get; set; }

        public virtual MediaCollection MediaCollection { get; set; }
    }
}
