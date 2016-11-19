namespace EntertainmentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Forum;
    using Models.Media;

    public class EntertainmentSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntertainmentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<MediaContent> MediaContents { get; set; }

        public IDbSet<MediaCategory> MediaCategories { get; set; }

        public IDbSet<MediaCollection> MediaCollections { get; set; }

        public IDbSet<Post> ForumPosts { get; set; }

        public IDbSet<ForumCategory> ForumCategories { get; set; }

        public IDbSet<Comment> ForumComments { get; set; }

        public IDbSet<Tag> ForumTags { get; set; }

        public IDbSet<VotePost> ForumPostVotes { get; set; }

        public IDbSet<VoteComment> ForumCommentVotes { get; set; }

        public static EntertainmentSystemDbContext Create()
        {
            return new EntertainmentSystemDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
