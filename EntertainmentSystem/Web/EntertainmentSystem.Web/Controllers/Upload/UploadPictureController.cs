namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Filters;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadPictureController : UploadBaseController
    {
        public UploadPictureController(IPictureUploadingGeneratorService pictureUploadingGeneratorService)
            : base(pictureUploadingGeneratorService)
        {
        }

        [AjaxPost]
        public ActionResult Create(PictureInputViewModel model)
        {
            return this.ConditionalActionResult(
                () => this.CreateContent(model.File),
                () => this.RedirectToAction("Index", "AdminMediaContent", new { area = GlobalConstants.AreaAdministrationName }));
        }
    }
}
