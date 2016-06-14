namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;
    using Infrastructure.Filters;

    public class PictureInputViewModel
    {
        [ValidatePictureFile]
        public HttpPostedFileBase File { get; set; }
    }
}
