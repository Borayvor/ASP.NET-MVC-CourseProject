namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System;
    using System.Web.Mvc;
    using Infrastructure.Filters;
    using Services.Data.MediaServices.Contracts.Generators;
    using ViewModels.Upload;

    [Authorize]
    [ValidateAntiForgeryToken]
    public class UploadPictureController : BaseUploadController
    {
        public UploadPictureController(IPictureUploadingGeneratorService pictureUploadingGeneratorService)
            : base(pictureUploadingGeneratorService)
        {
        }

        [AjaxPost]
        public ActionResult Create(PictureInputViewModel model)
        {
            return this.ConditionalActionResult<Guid>(
                () => this.CreateContent(model.File),
                (id) => this.PartialView(id));
        }
    }
}
