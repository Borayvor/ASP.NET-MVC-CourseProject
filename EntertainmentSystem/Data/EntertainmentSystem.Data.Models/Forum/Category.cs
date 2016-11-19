namespace EntertainmentSystem.Data.Models.Forum
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class Category : BaseModelGuid
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

        [Required]
        [MinLength(GlobalConstants.PostCategoryNameMinLength)]
        [MaxLength(GlobalConstants.PostCategoryNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
