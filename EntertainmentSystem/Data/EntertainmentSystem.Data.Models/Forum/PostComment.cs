namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class PostComment : BaseModelGuid
    {
        [Required]
        [MinLength(GlobalConstants.PostCommentContentMinLength)]
        [MaxLength(GlobalConstants.PostCommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
