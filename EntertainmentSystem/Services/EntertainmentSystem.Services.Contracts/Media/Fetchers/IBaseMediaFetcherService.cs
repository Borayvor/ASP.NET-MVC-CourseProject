namespace EntertainmentSystem.Services.Contracts.Media.Fetchers
{
    using System.Linq;
    using Data.Models.Media;

    public interface IBaseMediaFetcherService
    {
        IQueryable<MediaContent> All();

        IQueryable<MediaContent> SearchByTitle(string search);
    }
}
