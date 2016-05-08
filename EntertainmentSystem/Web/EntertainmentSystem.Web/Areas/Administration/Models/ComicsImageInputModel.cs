namespace EntertainmentSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.ImageModels;
    using Infrastructure.Mapping;

    public class ComicsImageInputModel : IMapTo<ComicsImage>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string FileFullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContentType { get; set; }

        public byte[] Image { get; set; }

        public int ComicsStoryId { get; set; }
    }
}
