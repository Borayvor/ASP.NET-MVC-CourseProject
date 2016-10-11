namespace EntertainmentSystem.Services.Contracts.Media
{
    using Common;
    using Data.Models.Media;

    public interface IMediaCategoryService : IBaseGetService<MediaCategory>,
        IBaseCreateService<MediaCategory>, IBaseUpdateService<MediaCategory>,
        IBaseDeleteService<MediaCategory>
    {
        /// <summary>
        /// Gets the category by name.
        /// </summary>
        /// <param name="name">The name of the category to get.</param>
        /// <returns>Category as class.</returns>
        MediaCategory GetByName(string name);
    }
}
