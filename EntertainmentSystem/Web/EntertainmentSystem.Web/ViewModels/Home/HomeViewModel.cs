namespace EntertainmentSystem.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using MediaContent;

    public class HomeViewModel
    {
        public IEnumerable<MediaContentHomeViewModel> Sounds { get; set; }

        public IEnumerable<MediaContentHomeViewModel> Pictures { get; set; }

        public IEnumerable<MediaContentHomeViewModel> Videos { get; set; }
    }
}
