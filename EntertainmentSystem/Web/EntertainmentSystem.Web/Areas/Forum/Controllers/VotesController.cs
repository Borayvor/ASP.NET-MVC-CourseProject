namespace EntertainmentSystem.Web.Areas.Forum.Controllers
{
    using System.Web.Mvc;
    using Services.Contracts.Forum;
    using Services.Contracts.Users;
    using Web.Controllers;

    public class VotesController : BaseController
    {
        private readonly IForumVoteService votes;
        private readonly IForumPostService posts;
        private readonly IUserService authors;

        public VotesController(IForumVoteService votes, IForumPostService posts, IUserService authors)
        {
            this.votes = votes;
            this.posts = posts;
            this.authors = authors;
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
