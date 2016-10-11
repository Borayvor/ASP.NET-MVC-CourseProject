namespace EntertainmentSystem.Services.Contracts.Media
{
    using System;
    using System.Linq;
    using Data.Models.Media;

    public interface IMaediaContentService
    {
        /// <summary>
        /// Get all contents. Without ordinary deleted.
        /// </summary>
        /// <returns>Contents as queryable.</returns>
        IQueryable<MediaContent> GetAll();

        /// <summary>
        /// Gets the content by id.
        /// </summary>
        /// <param name="id">The id of the content to get.</param>
        /// <returns>Content as class.</returns>
        MediaContent GetById(Guid id);

        /// <summary>
        /// Create new content.
        /// </summary>
        /// <param name="entity">Content to be created.</param>
        void Create(MediaContent entity);

        /// <summary>
        /// Update content.
        /// </summary>
        /// <param name="entity">Content to be updated.</param>
        void Update(MediaContent entity);

        /// <summary>
        /// Delete content. Not permanent.
        /// </summary>
        /// <param name="entity">Content to be deleted.</param>
        void Delete(MediaContent entity);
    }
}
