namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Media.Generators;
    using ViewModels.Upload;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
    [ValidateAntiForgeryToken]
    public abstract class UploadBaseController : BaseController
    {
        private const string ActionName = "Index";
        private const string AdminControllerName = "AdminMediaContent";
        private const string ModeratorControllerName = "ModeratorMediaContent";
        private const string ExceptionString = "Invalid file !";

        private readonly IUploadingGeneratorService uploadingGeneratorService;

        public UploadBaseController(IUploadingGeneratorService uploadingGeneratorService)
        {
            this.uploadingGeneratorService = uploadingGeneratorService;
        }

        protected ActionResult CreateFromModel(IUploadViewModel model)
        {
            var controllerInfo = this.GetControllerInfo();

            return this.ConditionalActionResult(
                () => this.CreateContent(model.File),
                () => this.RedirectToAction(
                    controllerInfo[0],
                    controllerInfo[1],
                    new { area = controllerInfo[2] }));
        }

        private void CreateContent(HttpPostedFileBase file)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException(this.ModelState.Values.FirstOrDefault() == null ? ExceptionString
                    : this.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            this.uploadingGeneratorService.Create(
                file.InputStream,
                this.HttpContext.User.Identity.GetUserId(),
                file.ContentType);
        }

        private string[] GetControllerInfo()
        {
            var action = ActionName;
            var controller = string.Empty;
            var area = string.Empty;

            if (this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                controller = ModeratorControllerName;
                area = GlobalConstants.AreaModeratorsName;
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                controller = AdminControllerName;
                area = GlobalConstants.AreaAdministrationName;
            }

            return new string[] { action, controller, area };
        }
    }
}
