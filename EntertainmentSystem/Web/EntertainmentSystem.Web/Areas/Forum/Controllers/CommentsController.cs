namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Contracts.Forum;
    using ViewModels;
    using Web.Controllers;

    public class CommentsController : BaseController
    {
        private readonly IForumCommentService commentService;

        public CommentsController(IForumCommentService commentService)
        {
            this.commentService = commentService;
        }

        [ChildActionOnly]
        public ActionResult PostComments(Guid postId)
        {
            return this.PartialView();
        }

        private PostCommentsPageViewModel GetCommentsPage(
            Guid id,
            int page = GlobalConstants.ForumStartPage)
        {
            var comments = this.commentService.GetAll().Where(c => c.PostId == id);

            int totalpages = 0;
            int pagesToSkip = (page - 1) * GlobalConstants.ForumCommentsPerPage;

            totalpages = (int)Math.Ceiling(comments.Count() / (decimal)GlobalConstants.ForumCommentsPerPage);

            var result = comments
                .Skip(pagesToSkip)
                .Take(GlobalConstants.ForumCommentsPerPage)
                .To<CommentViewModel>()
                .ToList();

            var newViewModel = new PostCommentsPageViewModel
            {
                Comments = result,
                CurrentPage = page,
                TotalPages = totalpages
            };

            return newViewModel;
        }
    }
}
