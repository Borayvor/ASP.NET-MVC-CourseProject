namespace EntertainmentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Entertainment;
    using Models.Forum;

    public class EntertainmentSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntertainmentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<MaediaContent> MaediaContentCollections { get; set; }

        public IDbSet<MediaCategory> MediaCategories { get; set; }

        public IDbSet<MediaCollection> MediaCollections { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<PostCategory> PostCategories { get; set; }

        public IDbSet<PostComment> PostComments { get; set; }

        public IDbSet<PostReComment> PostReComments { get; set; }

        public IDbSet<PostTag> PostTags { get; set; }

        public IDbSet<PostVote> PostVotes { get; set; }

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
