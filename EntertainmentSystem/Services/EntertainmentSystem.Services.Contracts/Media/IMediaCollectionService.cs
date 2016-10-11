namespace EntertainmentSystem.Services.Contracts.Media
{
    using System.Linq;
    using Data.Models.Media;

    public interface IMediaCollectionService
    {
        /// <summary>
        /// Get all collections. Without ordinary deleted.
        /// </summary>
        /// <returns>Collections as queryable.</returns>
        IQueryable<MediaCollection> GetAll();

        /// <summary>
        /// Gets the collection by id.
        /// </summary>
        /// <param name="id">The id of the collection to get.</param>
        /// <returns>Collection as class.</returns>
        MediaCollection GetById(int id);

        /// <summary>
        /// Create new collection.
        /// </summary>
        /// <param name="entity">Collection to be created.</param>
        void Create(MediaCollection entity);

        /// <summary>
        /// Update collection.
        /// </summary>
        /// <param name="entity">Collection to be updated.</param>
        void Update(MediaCollection entity);

        /// <summary>
        /// Delete collection. Not permanent.
        /// </summary>
        /// <param name="entity">Collection to be deleted.</param>
        void Delete(MediaCollection entity);
    }
}
