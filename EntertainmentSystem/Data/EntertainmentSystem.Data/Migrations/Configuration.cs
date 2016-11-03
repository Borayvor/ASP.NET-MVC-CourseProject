namespace EntertainmentSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Seeders;

    public sealed class Configuration : DbMigrationsConfiguration<EntertainmentSystemDbContext>
    {
        public Configuration()
        {
            ////#if DEBUG
            ////            this.AutomaticMigrationsEnabled = true;
            ////            this.AutomaticMigrationDataLossAllowed = true;
            ////#else
            ////            this.AutomaticMigrationsEnabled = false;
            ////            this.AutomaticMigrationDataLossAllowed = false;
            ////#endif

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
            StaticDataSeeder.SeedMediaCategory(context);
            StaticDataSeeder.SeedMediaCollection(context);
            StaticDataSeeder.SeedMediaContents(context);
        }
    }
}
