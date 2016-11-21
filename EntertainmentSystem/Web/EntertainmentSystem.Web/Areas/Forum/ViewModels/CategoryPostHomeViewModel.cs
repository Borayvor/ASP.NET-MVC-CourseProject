namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Collections.Generic;

    public class CategoryPostHomeViewModel
    {
        public string CategoryName { get; set; }

        public IEnumerable<PostHomeViewModel> Posts { get; set; }
    }
}
