namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Models.Forum;

    public class PostCategoryListViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public IEnumerable<PostCategory> Categories { get; set; }
    }
}
