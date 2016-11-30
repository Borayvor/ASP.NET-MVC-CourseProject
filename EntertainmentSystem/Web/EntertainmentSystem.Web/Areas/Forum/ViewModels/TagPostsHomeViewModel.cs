namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;

    public class TagPostsHomeViewModel
    {
        public string TagName { get; set; }

        public IEnumerable<PostHomeViewModel> Posts { get; set; }
    }
}
