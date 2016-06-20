namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Web.Mvc;
    using Data.Models.Media;
    using Services.Contracts.Media;

    public class AdminMediaContentController : AdminController
    {
        private readonly IAdminMediaService<MediaContent> adminMediaService;

        public AdminMediaContentController(IAdminMediaService<MediaContent> adminMediaService)
        {
            this.adminMediaService = adminMediaService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("_UploadMediaContent");
        }
    }
}
