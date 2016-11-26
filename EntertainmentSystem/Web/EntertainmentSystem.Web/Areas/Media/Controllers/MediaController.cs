namespace EntertainmentSystem.Web.Areas.Media.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;
    using ViewModels.Contracts;
    using Web.Controllers;

    [Authorize]
    public abstract class MediaController : BaseController
    {
        protected IMediaPageViewModel<T> GetMediaFilesPage<T>(
            IBaseMediaFetcherService service,
            int page,
            string search,
            string collectionName,
            string categoryName)
            where T : MediaBaseViewModel
        {
            var files = service.GetAll(search, collectionName, categoryName);

            int pagesToSkip = (page - 1) * GlobalConstants.MediaFilesPerPage;

            int totalpages = (int)Math.Ceiling(files.Count() / (decimal)GlobalConstants.MediaFilesPerPage);

            var filesPage = files
                .Skip(pagesToSkip)
                .Take(GlobalConstants.MediaFilesPerPage)
                .To<T>()
                .ToList();

            var newViewModel = new MediaPageViewModel<T>
            {
                MediaFiles = filesPage,
                CurrentPage = page,
                TotalPages = totalpages,
                Search = search,
                FilterByCollection = collectionName,
                FilterByCategory = categoryName
            };

            return newViewModel;
        }
    }
}
