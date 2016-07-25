namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;
    using Infrastructure.Filters;

    public class MusicInputViewModel
    {
        [ValidateMusicFile]
        public HttpPostedFileBase File { get; set; }
    }
}
