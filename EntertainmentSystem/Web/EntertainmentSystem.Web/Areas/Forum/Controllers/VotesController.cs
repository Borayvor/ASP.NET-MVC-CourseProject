namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models.Forum;
    using Microsoft.AspNet.Identity;
    using Services.Contracts.Forum;
    using Services.Contracts.Users;
    using ViewModels;
    using Web.Controllers;

    public class VotesController : BaseController
    {
        private readonly IForumVoteService votes;
        private readonly IForumPostService posts;
        private readonly IUserProfileService authors;

        public VotesController(IForumVoteService votes, IForumPostService posts, IUserProfileService authors)
        {
            this.votes = votes;
            this.posts = posts;
            this.authors = authors;
        }

        [ValidateAntiForgeryToken]
        public ActionResult Vote(VoteViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var author = this.authors.GetById(model.Post.AuthorId);

                author.VotePoints += (int)model.Value;
                this.authors.Update(author);

                var vote = this.votes.GetAll()
                    .FirstOrDefault(x => x.AuthorId == userId && x.PostId == model.Post.Id);

                if (vote == null)
                {
                    vote = new Vote
                    {
                        AuthorId = author.Id,
                        PostId = model.Post.Id,
                        CommentId = model.Comment.Id,
                        Value = model.Value
                    };

                    this.votes.Create(vote);
                }
                else
                {
                    vote.Value = model.Value;

                    this.votes.Update(vote);
                }
            }

            var newPostVotes = this.votes
                .GetAll()
                .Where(x => x.PostId == model.Post.Id)
                .Sum(x => (int?)x.Value ?? 0);

            return this.Json(new { VotesValue = newPostVotes });

            throw new HttpException(404, "not found !");
        }
    }
}
