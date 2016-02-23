namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.WordModels;
    using Infrastructure.Mapping;

    public class LanguageViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
