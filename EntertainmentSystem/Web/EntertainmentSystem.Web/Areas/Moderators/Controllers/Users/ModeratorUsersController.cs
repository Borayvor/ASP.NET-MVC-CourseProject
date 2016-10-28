namespace EntertainmentSystem.Web.Areas.Moderators.Controllers.Users
{
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Services.Contracts.Users;
    using ViewModels.User;

    public class ModeratorUsersController : ModeratorController
    {
        private readonly IUserModeratorService moderatorService;

        public ModeratorUsersController(IUserModeratorService moderatorService)
        {
            this.moderatorService = moderatorService;
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
            var data = this.moderatorService
                .GetAll()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, UserEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.moderatorService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.moderatorService.Update(entity);

                var viewModel = this.Mapper.Map<UserViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, UserViewModel model)
        {
            if (model != null)
            {
                var entity = this.moderatorService.GetById(model.Id);

                ApplicationUserManager userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                var roles = userManager.GetRoles(model.Id);

                if (roles.Count == 0)
                {
                    this.moderatorService.Delete(entity);
                }
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
