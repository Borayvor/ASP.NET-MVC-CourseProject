namespace EntertainmentSystem.Web.ViewModels.MediaContent
{
    using System;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaContentHomeViewModel : BaseViewModel<Guid>, IMapFrom<MediaContent>
    {
        public string Title { get; set; }

        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }
    }
}
