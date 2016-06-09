namespace EntertainmentSystem.Web.App_Start
{
    using System.Reflection;
    using Infrastructure.Mapping;

    public class AutoMapperAppConfig
    {
        public static void RegisterAutoMapper()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}
