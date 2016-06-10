namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class PostReComment : BaseModelGuid
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid CommentId { get; set; }

        public virtual PostComment Comment { get; set; }
    }
}
