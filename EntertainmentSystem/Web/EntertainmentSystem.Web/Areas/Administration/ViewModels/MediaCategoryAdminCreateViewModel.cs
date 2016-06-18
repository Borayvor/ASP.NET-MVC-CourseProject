namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryAdminCreateViewModel : IMapFrom<MediaCategory>, IMapTo<MediaCategory>
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
