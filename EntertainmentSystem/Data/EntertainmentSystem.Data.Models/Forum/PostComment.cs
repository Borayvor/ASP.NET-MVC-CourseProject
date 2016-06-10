namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class PostComment : BaseModelGuid
    {
        private ICollection<PostReComment> postReComments;

        public PostComment()
        {
            this.postReComments = new HashSet<PostReComment>();
        }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public Guid PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual ICollection<PostReComment> PostReComments
        {
            get { return this.postReComments; }
            set { this.postReComments = value; }
        }
    }
}
