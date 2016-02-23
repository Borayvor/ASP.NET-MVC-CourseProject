namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianQuestionViewModel : IMapFrom<BulgarianQuestion>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }
    }
}
