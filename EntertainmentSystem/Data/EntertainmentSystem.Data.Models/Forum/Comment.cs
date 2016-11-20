namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class Comment : BaseModelGuid
    {
        private ICollection<Vote> votes;

        public Comment()
        {
            this.votes = new HashSet<Vote>();
        }

        [Required]
        [MinLength(GlobalConstants.PostCommentContentMinLength)]
        [MaxLength(GlobalConstants.PostCommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
