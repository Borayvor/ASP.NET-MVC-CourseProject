namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class Post : BaseModelGuid
    {
        private ICollection<Tag> tags;
        private ICollection<Comment> comments;
        private ICollection<VotePost> votes;

        public Post()
        {
            this.tags = new HashSet<Tag>();
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<VotePost>();
        }

        [Required]
        [MinLength(GlobalConstants.PostTitleMinLength)]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(GlobalConstants.PostContentMinLength)]
        [MaxLength(GlobalConstants.PostContentMaxLength)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid PostCategoryId { get; set; }

        public virtual ForumCategory PostCategory { get; set; }

        public virtual ICollection<Tag> PostTags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<VotePost> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
