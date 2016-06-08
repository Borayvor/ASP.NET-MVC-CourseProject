namespace EntertainmentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.ComicsModels;
    using Models.ImageModels;
    using Models.WordModels;
    using Models.WordModels.Bulgarian;

    public class EntertainmentSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntertainmentSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Language> Languages { get; set; }

        public IDbSet<BulgarianWord> BulgarianWords { get; set; }

        public IDbSet<BulgarianQuestion> BulgarianQuestions { get; set; }

        public IDbSet<ComicsImage> ComicsImages { get; set; }

        public IDbSet<Comics> Comicses { get; set; }

        public IDbSet<ComicsStory> ComicsStories { get; set; }

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
