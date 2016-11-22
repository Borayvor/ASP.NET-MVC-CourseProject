namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;

    public class PostCommentsPageViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
