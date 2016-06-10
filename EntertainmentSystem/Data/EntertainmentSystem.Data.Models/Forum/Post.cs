﻿namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Post : BaseModelGuid
    {
        private ICollection<PostTag> tags;
        private ICollection<PostComment> comments;
        private ICollection<PostVote> votes;

        public Post()
        {
            this.tags = new HashSet<PostTag>();
            this.comments = new HashSet<PostComment>();
            this.votes = new HashSet<PostVote>();
        }

        [Required]
        [MaxLength(256)]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid PostCategoryId { get; set; }

        public virtual PostCategory PostCategory { get; set; }

        public virtual ICollection<PostTag> PostTags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<PostComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<PostVote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
