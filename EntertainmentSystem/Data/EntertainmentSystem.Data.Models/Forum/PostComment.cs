namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class PostComment : BaseModelGuid
    {
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
