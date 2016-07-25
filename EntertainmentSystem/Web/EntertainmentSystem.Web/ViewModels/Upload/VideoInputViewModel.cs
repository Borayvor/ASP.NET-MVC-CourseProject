namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;
    using Infrastructure.Filters;

    public class VideoInputViewModel
    {
        [ValidateVideoFile]
        public HttpPostedFileBase File { get; set; }
    }
}
