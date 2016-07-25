namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Infrastructure.Filters;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadMusicController : UploadBaseController
    {
        public UploadMusicController(IMusicUploadingGeneratorService musicUploadingGeneratorService)
            : base(musicUploadingGeneratorService)
        {
        }

        [AjaxPost]
        public ActionResult Create(MusicInputViewModel model)
        {
            var controllerInfo = this.GetControllerInfo();

            return this.ConditionalActionResult(
                () => this.CreateContent(model.File),
                () => this.RedirectToAction(controllerInfo[0], controllerInfo[1], new { area = controllerInfo[2] }));
        }
    }
}
