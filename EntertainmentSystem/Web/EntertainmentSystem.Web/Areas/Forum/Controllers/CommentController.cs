namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Data.Models.Forum;
    using Infrastructure.Sanitizer;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
    [ValidateAntiForgeryToken]
    public class CommentController : BaseController
    {
        private ISanitizer sanitizer;
        private IForumCommentService commentService;

        public CommentController(ISanitizer sanitizer, IForumCommentService commentService)
        {
            this.sanitizer = sanitizer;
            this.commentService = commentService;
        }

        public ActionResult Create(ComentCreateViewModel model)
        {
            var result = this.ConditionalActionResult(
                () => this.CreateComment(model),
                (content) => this.PartialView(content));

            return result;
        }

        private CommentViewModel CreateComment(ComentCreateViewModel model)
        {
            var sanitizedCommentContent = this.sanitizer.Sanitize(model.Content);

            var comment = new Comment
            {
                AuthorId = this.User.Identity.GetUserId(),
                Content = sanitizedCommentContent,
                PostId = model.PostId
            };

            this.commentService.Create(comment);

            var viewModel = this.Mapper.Map<CommentViewModel>(comment);

            return viewModel;
        }
    }
}
