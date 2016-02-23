namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.WordModels;
    using Infrastructure.Mapping;

    public class BulgarianQuestionInputModel : IMapTo<Language>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int WordId { get; set; }
    }
}
