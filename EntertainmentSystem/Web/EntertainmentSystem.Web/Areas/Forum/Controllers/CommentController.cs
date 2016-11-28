namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Data.Models.Forum;
    using Infrastructure.Sanitizer;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Forum;
    using Services.Contracts.Users;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
    [ValidateAntiForgeryToken]
    public class CommentController : BaseController
    {
        private readonly IForumCommentService commentService;
        private readonly IUserProfileService userService;

        private ISanitizer sanitizer;

        public CommentController(
            IForumCommentService commentService,
            IUserProfileService userService,
            ISanitizer sanitizer)
        {
            this.commentService = commentService;
            this.userService = userService;
            this.sanitizer = sanitizer;
        }

        public ActionResult Create(ComentCreateViewModel model)
        {
            var result = this.ConditionalActionResult(
                () => this.CreateComment(model),
                (content) => this.PartialView("_PostCommentPartial", content));

            return result;
        }

        private CommentViewModel CreateComment(ComentCreateViewModel model)
        {
            ////var sanitizedCommentContent = this.sanitizer.Sanitize(model.Content);
            var currentUser = this.userService.GetById(this.User.Identity.GetUserId());

            var comment = new Comment
            {
                Author = currentUser,
                Content = model.Content,
                PostId = model.PostId
            };

            this.commentService.Create(comment);

            var viewModel = this.Mapper.Map<CommentViewModel>(comment);

            return viewModel;
        }
    }
}
