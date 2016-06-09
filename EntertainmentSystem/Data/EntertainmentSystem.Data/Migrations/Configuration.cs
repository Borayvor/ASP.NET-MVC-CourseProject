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
            StaticDataSeeder.SeedUsers(context);
        }
    }
}
