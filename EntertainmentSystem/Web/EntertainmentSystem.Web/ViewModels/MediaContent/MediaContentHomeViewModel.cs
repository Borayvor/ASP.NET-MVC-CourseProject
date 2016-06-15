namespace EntertainmentSystem.Web.ViewModels.MediaContent
{
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaContentHomeViewModel : IMapFrom<MediaContent>
    {
        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }
    }
}
