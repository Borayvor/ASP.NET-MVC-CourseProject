namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Users
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
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
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, AdminUserViewModel model)
        {
            if (model != null)
            {
                var entity = this.usersAdminService.GetById(model.Id);

                this.usersAdminService.Delete(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestroyPermanent([DataSourceRequest]DataSourceRequest request, AdminUserViewModel model)
        {
            if (model != null)
            {
                var entity = this.usersAdminService.GetById(model.Id);

                this.usersAdminService.DeletePermanent(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
