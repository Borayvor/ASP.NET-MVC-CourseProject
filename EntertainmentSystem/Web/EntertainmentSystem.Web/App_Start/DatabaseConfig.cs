namespace EntertainmentSystem.Web.App_Start
{
    using System.Data.Entity;
    using Data;

    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            ////Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntertainmentSystemDbContext, Configuration>());

            Database.SetInitializer(new DropCreateDatabaseAlways<EntertainmentSystemDbContext>());

            EntertainmentSystemDbContext.Create().Database.Initialize(true);
        }
    }
}
