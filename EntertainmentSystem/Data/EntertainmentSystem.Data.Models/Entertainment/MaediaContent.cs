namespace EntertainmentSystem.Data.Models.Entertainment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class MaediaContent : BaseModelGuid
    {
        [MaxLength(512)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1024)]
        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid MediaCategoryId { get; set; }

        public virtual MediaCategory MediaCategory { get; set; }

        public Guid MediaCollectionId { get; set; }

        public virtual MediaCollection MediaCollection { get; set; }
    }
}
