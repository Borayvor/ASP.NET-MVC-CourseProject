namespace InteractiveLearningSystem.Web.Areas.Administration.Models
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
        [MinLength(1)]
        [MaxLength(500)]
        public string FileName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        public string Extension { get; set; }

        [Range(0, int.MaxValue)]
        public int Position { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public int ComicsId { get; set; }
    }
}
