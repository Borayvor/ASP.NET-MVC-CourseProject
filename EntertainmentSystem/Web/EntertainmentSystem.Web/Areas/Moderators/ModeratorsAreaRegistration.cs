﻿namespace EntertainmentSystem.Web.Areas.Moderators
{
    using System.Web.Mvc;

    public class ModeratorsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Moderators";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Moderators_default",
                "Moderators/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
