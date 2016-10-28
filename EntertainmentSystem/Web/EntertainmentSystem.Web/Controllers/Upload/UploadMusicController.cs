namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System.Web.Mvc;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    public class UploadMusicController : UploadBaseController
    {
        public UploadMusicController(IMusicUploadingGeneratorService musicUploadingGeneratorService)
            : base(musicUploadingGeneratorService)
        {
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView("_UploadMusicPartial");
        }

        [HttpPost]
        public ActionResult Create(MusicUploadViewModel model)
        {
            return this.CreateFromModel(model);
        }
    }
}
