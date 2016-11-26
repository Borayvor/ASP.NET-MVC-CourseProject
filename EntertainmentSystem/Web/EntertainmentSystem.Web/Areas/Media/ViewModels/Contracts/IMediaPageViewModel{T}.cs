namespace EntertainmentSystem.Web.Areas.Media.ViewModels.Contracts
{
    using System.Collections.Generic;

    public interface IMediaPageViewModel<T>
        where T : MediaBaseViewModel
    {
        IEnumerable<T> MediaFiles { get; set; }

        int TotalPages { get; set; }

        int CurrentPage { get; set; }

        string Search { get; set; }

        string FilterByCollection { get; set; }

        string FilterByCategory { get; set; }
    }
}
