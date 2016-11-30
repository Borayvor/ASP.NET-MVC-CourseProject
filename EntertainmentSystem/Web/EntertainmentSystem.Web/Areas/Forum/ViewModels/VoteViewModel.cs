namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;

    public class VoteViewModel
    {
        public VoteType Value { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public string ModelId { get; set; }
    }
}
