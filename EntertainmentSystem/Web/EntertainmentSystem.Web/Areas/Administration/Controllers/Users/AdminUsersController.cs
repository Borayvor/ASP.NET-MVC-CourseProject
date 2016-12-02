namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Users
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Services.Contracts.Users;
    using ViewModels;

    public class AdminUsersController : AdminController
    {
        private readonly IUserAdminService usersAdminService;

        public AdminUsersController(IUserAdminService usersAdminService)
        {
            this.usersAdminService = usersAdminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.usersAdminService
                .GetAllWithDeleted()
                .To<AdminUserViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdminUserEditViewModel model)
        {
            ////if (model != null && this.ModelState.IsValid)
            ////{
            ////    var roles = this.GetUserRoles(model.Id);

            ////    if (roles == null || roles.Contains(GlobalConstants.AdministratorRoleName) == false)
            ////    {
            ////        var entity = this.usersAdminService.GetById(model.Id);

            ////        this.Mapper.Map(model, entity);

            ////        this.usersAdminService.Update(entity);

            ////        var viewModel = this.Mapper.Map<AdminUserViewModel>(entity);

            ////        return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            ////    }
            ////}

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestroyPermanent([DataSourceRequest]DataSourceRequest request, AdminUserViewModel model)
        {
            ////if (model != null)
            ////{
            ////    var roles = this.GetUserRoles(model.Id);

            ////    if (roles == null || roles.Contains(GlobalConstants.AdministratorRoleName) == false)
            ////    {
            ////        var entity = this.usersAdminService.GetById(model.Id);

            ////        this.usersAdminService.DeletePermanent(entity);
            ////    }
            ////}

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        private IList<string> GetUserRoles(string id)
        {
            ApplicationUserManager userManager = this.HttpContext.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            return userManager.GetRoles(id);
        }
    }
}
