namespace EntertainmentSystem.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class Tag : BaseModel<int>
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(GlobalConstants.PostTagNameMinLength)]
        [MaxLength(GlobalConstants.PostTagNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
