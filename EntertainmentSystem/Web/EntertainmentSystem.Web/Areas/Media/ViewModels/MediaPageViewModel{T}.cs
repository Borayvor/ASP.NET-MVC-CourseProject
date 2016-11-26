namespace EntertainmentSystem.Web.Areas.Media.ViewModels
{
    using System.Collections.Generic;
    using Contracts;

    public class MediaPageViewModel<T> : IMediaPageViewModel<T>
        where T : MediaBaseViewModel
    {
        public IEnumerable<T> MediaFiles { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }

        public string Search { get; set; }

        public string FilterByCollection { get; set; }

        public string FilterByCategory { get; set; }
    }
}
