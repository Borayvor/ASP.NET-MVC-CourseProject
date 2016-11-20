namespace EntertainmentSystem.Web.Controllers.Users
{
    using System.Web.Mvc;
    using Services.Contracts.Users;
    using ViewModels.User;

    public class UsersController : BaseController
    {
        private readonly IUserProfileService userProfileService;

        public UsersController(IUserProfileService userProfileService)
        {
            this.userProfileService = userProfileService;
        }

        public ActionResult Index(string id)
        {
            var result = this.ConditionalActionResult(
                () => this.Mapper.Map<UserProfileViewModel>(this.userProfileService.GetById(id)),
                (content) => this.View(content));

            return result;
        }
    }
}
