namespace EntertainmentSystem.Web.ViewModels.Upload
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UploadFileInfoViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [UIHint("DropDownListCategories")]
        public Guid CategoryId { get; set; }

        [UIHint("DropDownListCollections")]
        public Guid? CollectionId { get; set; }
    }
}
