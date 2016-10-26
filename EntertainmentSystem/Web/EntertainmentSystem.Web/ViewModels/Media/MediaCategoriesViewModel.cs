namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System.Collections.Generic;

    public class MediaCategoriesViewModel
    {
        public IEnumerable<MediaCategoryEditViewModel> Categories { get; set; }
    }
}
