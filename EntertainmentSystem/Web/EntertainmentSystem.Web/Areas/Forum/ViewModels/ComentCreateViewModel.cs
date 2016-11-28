namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ComentCreateViewModel
    {
        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [HiddenInput(DisplayValue = false)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid PostId { get; set; }
    }
}
