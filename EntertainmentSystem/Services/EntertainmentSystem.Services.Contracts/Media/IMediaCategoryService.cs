namespace EntertainmentSystem.Services.Contracts.Media
{
    using System;
    using Common;
    using Data.Models.Media;

    public interface IMediaCategoryService : IBaseGetService<MediaCategory, Guid>,
        IBaseCreateService<MediaCategory>, IBaseUpdateService<MediaCategory>,
        IBaseDeleteService<MediaCategory>
    {
        /// <summary>
        /// Gets the MediaCategory by name.
        /// </summary>
        /// <param name="name">The name of the MediaCategory to get.</param>
        /// <returns>MediaCategory with name <"name">.</returns>
        MediaCategory GetByName(string name);
    }
}
