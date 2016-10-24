namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System.Collections.Generic;

    public class CategoryAndCollectionViewModel
    {
        public IEnumerable<MediaCategoryViewModel> Categories { get; set; }

        public IEnumerable<MediaCollectionViewModel> Collections { get; set; }
    }
}
