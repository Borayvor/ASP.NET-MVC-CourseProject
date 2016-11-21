namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;

    public class PostsPageViewModel
    {
        public IEnumerable<PostHomeViewModel> Posts { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public string Search { get; set; }
    }
}
