namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Common.Constants;
    using Infrastructure.Filters;

    public class PictureUploadViewModel : IUploadViewModel
    {
        [Required(ErrorMessage = ExceptionMessages.FileMissingMessage)]
        [ValidatePictureFile]
        public HttpPostedFileBase File { get; set; }

        public UploadFileInfoViewModel FileInfo { get; set; }
    }
}
