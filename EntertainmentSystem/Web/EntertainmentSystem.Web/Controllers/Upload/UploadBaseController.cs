﻿namespace EntertainmentSystem.Web.Controllers.Upload
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
        private const string ExceptionForFile = "Invalid file !";
        private const string ExceptionForFileInfo = "Invalid file info !";

        private readonly IUploadingGeneratorService uploadingGeneratorService;

        public UploadBaseController(IUploadingGeneratorService uploadingGeneratorService)
        {
            this.uploadingGeneratorService = uploadingGeneratorService;
        }

        protected ActionResult CreateFromModel(IUploadViewModel model)
        {
            var controllerInfo = this.GetControllerInfo();

            return this.ConditionalActionResult(
                () => this.CreateContent(model.File, model.FileInfo),
                () => this.RedirectToAction(
                    controllerInfo[0],
                    controllerInfo[1],
                    new { area = controllerInfo[2] }));
        }

        private void CreateContent(HttpPostedFileBase file, UploadFileInfoViewModel fileInfo)
        {
            this.CheckFileModel(file);
            this.CheckFileInfoModel(fileInfo);

            string coverImageUrl = "https://dl.dropboxusercontent.com/1/view/jm0poduvuxj8ekh/Apps/EntertainmentSystem/88518440-dd5d-46e3-9f4a-7b2e8c3d8cec.jpg";

            var contentId = this.uploadingGeneratorService.Create(
                file.InputStream,
                file.ContentType,
                this.User.Identity.GetUserId(),
                fileInfo.Title,
                fileInfo.Description,
                coverImageUrl,
                fileInfo.CategoryId,
                fileInfo.CollectionId);
        }

        private void CheckFileModel(HttpPostedFileBase file)
        {
            // TODO: reafactor for null HttpPostedFileBase
            if (file == null || !this.ModelState.IsValid)
            {
                throw new ArgumentException(this.ModelState.Values.FirstOrDefault() == null ? ExceptionForFile
                    : this.ModelState.Values.FirstOrDefault(m => m.Errors.Count > 0).Errors.FirstOrDefault().ErrorMessage);
            }
        }

        private void CheckFileInfoModel(UploadFileInfoViewModel fileInfo)
        {
            // TODO: reafactor for null UploadFileInfoViewModel
            if (fileInfo == null || !this.ModelState.IsValid)
            {
                throw new ArgumentException(ExceptionForFileInfo);
            }
        }

        private string[] GetControllerInfo()
        {
            var action = ActionName;
            var controller = string.Empty;
            var area = string.Empty;

            if (this.User.IsInRole(GlobalConstants.ModeratorRoleName))
            {
                controller = ModeratorControllerName;
                area = GlobalConstants.ModeratorAreaName;
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                controller = AdminControllerName;
                area = GlobalConstants.AdministratorAreaName;
            }

            return new string[] { action, controller, area };
        }
    }
}
