namespace EntertainmentSystem.Data.Models.Media
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class MaediaContent : BaseModelGuid
    {
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int MediaCategoryId { get; set; }

        public virtual MediaCategory MediaCategory { get; set; }

        public int MediaCollectionId { get; set; }

        public virtual MediaCollection MediaCollection { get; set; }
    }
}
