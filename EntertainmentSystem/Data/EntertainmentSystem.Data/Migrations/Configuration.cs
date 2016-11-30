namespace EntertainmentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<EntertainmentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EntertainmentSystemDbContext context)
        {
            StaticDataSeeder.SeedRoles(context);
            StaticDataSeeder.SeedUsers(context);

            StaticDataSeeder.SeedPostCategories(context);
            StaticDataSeeder.SeedPosts(context);
            StaticDataSeeder.SeedTags(context);
            StaticDataSeeder.SeedPostComments(context);
            StaticDataSeeder.SeedPostVotes(context);
            StaticDataSeeder.SeedCommentVotes(context);

            StaticDataSeeder.SeedMediaCategory(context);
            StaticDataSeeder.SeedMediaCollection(context);
            StaticDataSeeder.SeedMediaContents(context);
        }
    }
}
