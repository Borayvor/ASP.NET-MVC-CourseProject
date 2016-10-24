namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.Web;

    public interface IUploadViewModel
    {
        HttpPostedFileBase File { get; set; }

        UploadFileInfoViewModel FileInfo { get; set; }
    }
}
