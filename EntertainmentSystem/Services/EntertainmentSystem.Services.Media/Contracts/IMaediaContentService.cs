namespace EntertainmentSystem.Services.Media.Contracts
{
    using System;
    using System.Linq;
    using EntertainmentSystem.Data.Models.Media;

    public interface IMaediaContentService
    {
        /// <summary>
        /// Get all contents. Without ordinary deleted.
        /// </summary>
        /// <returns>Contents as queryable.</returns>
        IQueryable<MaediaContent> GetAll();

        /// <summary>
        /// Gets the content by id.
        /// </summary>
        /// <param name="id">The id of the content to get.</param>
        /// <returns>Content as class.</returns>
        MaediaContent GetById(Guid id);

        /// <summary>
        /// Create new content.
        /// </summary>
        /// <param name="content">Content to be created.</param>
        void Create(MaediaContent content);

        /// <summary>
        /// Update content.
        /// </summary>
        /// <param name="content">Content to be updated.</param>
        void Update(MaediaContent content);

        /// <summary>
        /// Delete content. Not permanent.
        /// </summary>
        /// <param name="content">Content to be deleted.</param>
        void Delete(MaediaContent content);
    }
}
