namespace InteractiveLearningSystem.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InteractiveLearningSystemDbContext, Configuration>());
            InteractiveLearningSystemDbContext.Create().Database.Initialize(true);
        }
    }
}
