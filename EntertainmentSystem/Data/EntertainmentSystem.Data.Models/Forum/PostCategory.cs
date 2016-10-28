namespace EntertainmentSystem.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class PostCategory : BaseModelGuid
    {
        private ICollection<Post> posts;

        public PostCategory()
        {
            this.posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
