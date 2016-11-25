namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Data.Models.Forum;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Forum;
    using Services.Contracts.Users;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
    public class VotesController : BaseController
    {
        private readonly IForumPostVoteService postVoteService;
        private readonly IForumCommentVoteService commentVoteService;
        private readonly IUserProfileService userService;

        public VotesController(
            IForumPostVoteService postVoteService,
            IForumCommentVoteService commentVoteService,
            IUserProfileService userService)
        {
            this.postVoteService = postVoteService;
            this.commentVoteService = commentVoteService;
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult PostVote(VoteViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var postAuthor = this.userService.GetById(model.AuthorId);
                Guid postId = model.ModelId == null ? Guid.Empty : Guid.Parse(model.ModelId);
                var votePointsToAdd = (int)model.Value;

                var vote = this.postVoteService.GetAll()
                    .FirstOrDefault(x => x.AuthorId == userId && x.PostId == postId);

                if (vote == null)
                {
                    vote = new PostVote
                    {
                        AuthorId = userId,
                        PostId = postId,
                        Value = model.Value
                    };

                    this.postVoteService.Create(vote);
                }
                else
                {
                    if (model.Value == VoteType.Negative && model.Value == vote.Value)
                    {
                        model.Value = VoteType.Neutral;
                        votePointsToAdd = (int)VoteType.Positive;
                    }
                    else if (model.Value == VoteType.Positive && model.Value == vote.Value)
                    {
                        model.Value = VoteType.Neutral;
                        votePointsToAdd = (int)VoteType.Negative;
                    }
                    else if (model.Value != vote.Value)
                    {
                        votePointsToAdd += (int)model.Value;
                    }

                    vote.Value = model.Value;

                    this.postVoteService.Update(vote);
                }

                postAuthor.VotePoints += votePointsToAdd;
                this.userService.Update(postAuthor);

                var newVotes = this.postVoteService
                .GetAll()
                .Where(x => x.PostId == postId)
                .Sum(x => (int?)x.Value ?? 0);

                return this.Json(new { VotesValue = newVotes });
            }

            throw new HttpException(404, "Post vote model not found !");
        }

        [HttpPost]
        public ActionResult CommentVote(VoteViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var postAuthor = this.userService.GetById(model.AuthorId);
                Guid commentId = model.ModelId == null ? Guid.Empty : Guid.Parse(model.ModelId);
                var votePointsToAdd = (int)model.Value;

                var vote = this.commentVoteService.GetAll()
                    .FirstOrDefault(x => x.AuthorId == userId && x.CommentId == commentId);

                if (vote == null)
                {
                    vote = new CommentVote
                    {
                        AuthorId = userId,
                        CommentId = commentId,
                        Value = model.Value
                    };

                    this.commentVoteService.Create(vote);
                }
                else
                {
                    if (model.Value == VoteType.Negative && model.Value == vote.Value)
                    {
                        model.Value = VoteType.Neutral;
                        votePointsToAdd = (int)VoteType.Positive;
                    }
                    else if (model.Value == VoteType.Positive && model.Value == vote.Value)
                    {
                        model.Value = VoteType.Neutral;
                        votePointsToAdd = (int)VoteType.Negative;
                    }

                    vote.Value = model.Value;

                    this.commentVoteService.Update(vote);
                }

                postAuthor.VotePoints += votePointsToAdd;
                this.userService.Update(postAuthor);

                var newVotes = this.commentVoteService
                .GetAll()
                .Where(x => x.CommentId == commentId)
                .Sum(x => (int?)x.Value ?? 0);

                return this.Json(new { VotesValue = newVotes });
            }

            throw new HttpException(404, "Comment vote model not found !");
        }
    }
}
