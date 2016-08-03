namespace EntertainmentSystem.Web.Areas.Media
{
    using System.Web.Mvc;

    public class MediaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Media";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Media_default",
                "Media/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
