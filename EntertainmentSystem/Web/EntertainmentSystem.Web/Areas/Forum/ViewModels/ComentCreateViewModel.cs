namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Web.Mvc;

    public class ComentCreateViewModel
    {
        [AllowHtml]
        [HiddenInput(DisplayValue = false)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Guid PostId { get; set; }
    }
}
