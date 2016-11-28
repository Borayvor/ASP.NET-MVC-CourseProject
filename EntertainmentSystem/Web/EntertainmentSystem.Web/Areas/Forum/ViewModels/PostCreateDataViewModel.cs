namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;
    using Data.Models.Forum;

    public class PostCreateDataViewModel
    {
        public PostCreateViewModel Post { get; set; }

        public IEnumerable<PostCategory> Categories { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
