namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Media.Generators;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [ValidateAntiForgeryToken]
    public abstract class UploadBaseController : BaseController
    {
        private readonly IUploadingGeneratorService uploadingGeneratorService;

        public UploadBaseController(IUploadingGeneratorService uploadingGeneratorService)
        {
            this.uploadingGeneratorService = uploadingGeneratorService;
        }

        public Guid CreateContent(HttpPostedFileBase file)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException(this.ModelState.Values.FirstOrDefault() == null ? "Invalid file"
                    : this.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage);
            }

            return this.uploadingGeneratorService.Create(
                file.InputStream,
                this.HttpContext.User.Identity.GetUserId(),
                file.ContentType);
        }
    }
}
