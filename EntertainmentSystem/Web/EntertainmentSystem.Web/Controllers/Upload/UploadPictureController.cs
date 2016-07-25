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
            var action = "Index";
            var controller = string.Empty;
            var currentArea = string.Empty;

            if (this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                controller = "ModeratorMediaContent";
                currentArea = GlobalConstants.AreaModeratorsName;
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                controller = "AdminMediaContent";
                currentArea = GlobalConstants.AreaAdministrationName;
            }
            else
            {
                return this.HttpNotFound();
            }

            return this.ConditionalActionResult(
                () => this.CreateContent(model.File),
                () => this.RedirectToAction(action, controller, new { area = currentArea }));
        }
    }
}
