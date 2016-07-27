namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Media.Generators;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName + "," + GlobalConstants.ModeratorRoleName)]
    [ValidateAntiForgeryToken]
    public abstract class UploadBaseController : BaseController
    {
        private readonly IUploadingGeneratorService uploadingGeneratorService;

        public UploadBaseController(IUploadingGeneratorService uploadingGeneratorService)
        {
            this.uploadingGeneratorService = uploadingGeneratorService;
        }

        public void CreateContent(HttpPostedFileBase file)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException(this.ModelState.Values.FirstOrDefault() == null ? "Invalid file"
                    : this.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            this.uploadingGeneratorService.Create(
                file.InputStream,
                this.HttpContext.User.Identity.GetUserId(),
                file.ContentType);
        }

        protected string[] GetControllerInfo()
        {
            var action = "Index";
            var controller = string.Empty;
            var area = string.Empty;

            if (this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                controller = "ModeratorMediaContent";
                area = GlobalConstants.AreaModeratorsName;
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                controller = "AdminMediaContent";
                area = GlobalConstants.AreaAdministrationName;
            }

            return new string[] { action, controller, area };
        }
    }
}
