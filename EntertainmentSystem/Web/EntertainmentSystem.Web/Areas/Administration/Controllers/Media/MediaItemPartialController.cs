namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System;
    using System.Web.Mvc;

    public class MediaItemPartialController : Controller
    {
        [ChildActionOnly]
        public ActionResult GetFromId(Guid id)
        {
            return this.PartialView();
        }
    }
}
