namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
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
            var controllerInfo = this.GetControllerInfo();

            return this.ConditionalActionResult(
                () => this.CreateContent(model.File),
                () => this.RedirectToAction(
                    controllerInfo[0],
                    controllerInfo[1],
                    new { area = controllerInfo[2] }));
        }
    }
}
