﻿namespace EntertainmentSystem.Web.ViewModels.MediaContentModels
{
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaContentHomeViewModel : IMapFrom<MediaContent>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ContentUrl { get; set; }

        public ContentType ContentType { get; set; }
    }
}
