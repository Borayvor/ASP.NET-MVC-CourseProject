namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadPictureController : UploadBaseController
    {
        public UploadPictureController(IPictureUploadingGeneratorService pictureUploadingGeneratorService)
            : base(pictureUploadingGeneratorService)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("_UploadPicturePartial");
        }

        [HttpPost]
        public ActionResult Create(PictureUploadViewModel model)
        {
            return this.CreateFromModel(model);
        }
    }
}
