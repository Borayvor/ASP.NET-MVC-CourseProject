namespace EntertainmentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Forum;
    using Media;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<MediaContent> mediaContentCollections;
        private ICollection<Post> posts;
        private ICollection<PostComment> comments;
        private ICollection<PostReComment> commentsOfComment;
        private ICollection<PostVote> votes;

        public ApplicationUser()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;

            this.mediaContentCollections = new HashSet<MediaContent>();
            this.posts = new HashSet<Post>();
            this.comments = new HashSet<PostComment>();
            this.commentsOfComment = new HashSet<PostReComment>();
            this.votes = new HashSet<PostVote>();
        }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string LastName { get; set; }

        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        public virtual ICollection<MediaContent> MaediaContentCollections
        {
            get { return this.mediaContentCollections; }
            set { this.mediaContentCollections = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        public virtual ICollection<PostComment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<PostReComment> ReComments
        {
            get { return this.commentsOfComment; }
            set { this.commentsOfComment = value; }
        }

        public virtual ICollection<PostVote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
