namespace EntertainmentSystem.Web.Controllers.Upload
{
    using System;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Services.Data.EntertainmentServices.Contracts.Generators;

    public abstract class BaseUploadController : BaseController
    {
        private readonly IUploadingGeneratorService uploadingGeneratorService;

        public BaseUploadController(IUploadingGeneratorService uploadingGeneratorService)
        {
            this.uploadingGeneratorService = uploadingGeneratorService;
        }

        public IUploadingGeneratorService UploadingGeneratorService
        {
            get { return this.uploadingGeneratorService; }
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
