namespace EntertainmentSystem.Web.ViewModels.MediaCategoryModels
{
    using System.Collections.Generic;

    public class MediaCategoryListUploadViewModel
    {
        public IEnumerable<MediaCategoryUploadViewModel> Categories { get; set; }
    }
}
