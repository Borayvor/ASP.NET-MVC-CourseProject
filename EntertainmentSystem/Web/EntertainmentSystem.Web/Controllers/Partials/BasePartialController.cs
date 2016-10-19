namespace EntertainmentSystem.Web.Controllers.Partials
{
    using System;
    using System.Web.Mvc;
    using Services.Web;

    public abstract class BasePartialController : BaseController
    {
        private readonly ICacheService cache;

        public BasePartialController(ICacheService cache)
        {
            this.cache = cache;
        }

        public ActionResult PartialActionResult(string itemName, Func<ActionResult> getDataFunc, int durationInSeconds)
        {
            return this.cache.Get(itemName, getDataFunc, durationInSeconds);
        }
    }
}
