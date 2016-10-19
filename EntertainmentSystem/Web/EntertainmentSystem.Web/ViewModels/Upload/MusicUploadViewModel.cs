namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;
    using Infrastructure.Filters;

    public class MusicUploadViewModel : IUploadViewModel
    {
        [ValidateMusicFile]
        public HttpPostedFileBase File { get; set; }
    }
}
