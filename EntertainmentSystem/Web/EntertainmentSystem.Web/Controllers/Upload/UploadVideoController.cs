namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Infrastructure.Filters;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadVideoController : UploadBaseController
    {
        public UploadVideoController(IVideoUploadingGeneratorService videoUploadingGeneratorService)
            : base(videoUploadingGeneratorService)
        {
        }

        [AjaxPost]
        public ActionResult Create(VideoInputViewModel model)
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
