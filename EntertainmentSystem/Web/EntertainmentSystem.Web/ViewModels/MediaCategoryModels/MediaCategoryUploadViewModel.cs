namespace EntertainmentSystem.Web.ViewModels.MediaCategoryModels
{
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryUploadViewModel : IMapFrom<MediaCategory>
    {
        public string Name { get; set; }
    }
}
