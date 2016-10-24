namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;
    using Infrastructure.Filters;

    public class VideoUploadViewModel : IUploadViewModel
    {
        [ValidateVideoFile]
        public HttpPostedFileBase File { get; set; }

        public UploadFileInfoViewModel FileInfo { get; set; }
    }
}
