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
        public ActionResult Create(MusicUploadViewModel model)
        {
            return this.CreateFromModel(model);
        }
    }
}
