namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadVideoController : UploadBaseController
    {
        public UploadVideoController(IVideoUploadingGeneratorService videoUploadingGeneratorService)
            : base(videoUploadingGeneratorService)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("_UploadVideoPartial");
        }

        [HttpPost]
        public ActionResult Create(VideoUploadViewModel model)
        {
            return this.CreateFromModel(model);
        }
    }
}
