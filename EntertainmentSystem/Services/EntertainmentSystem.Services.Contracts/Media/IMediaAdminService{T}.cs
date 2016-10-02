namespace EntertainmentSystem.Services.Contracts.Media
{
    using System;
    using System.Linq;
    using Data.Common.Models;

    public interface IMediaAdminService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Get all <"T">. Without ordinary deleted.
        /// </summary>
        /// <returns><"T"> as queryable.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get all <"T">. With ordinary deleted.
        /// </summary>
        /// <returns><"T"> as queryable.</returns>
        IQueryable<T> GetAllWithDeleted();

        /// <summary>
        /// Gets the <"T"> by id.
        /// </summary>
        /// <param name="id">The id of the <"T"> to get.</param>
        T GetById(Guid id);

        /// <summary>
        /// Create new <"T">.
        /// </summary>
        /// <param name="content"><"T"> to be created.</param>
        void Create(T entity);

        /// <summary>
        /// Update <"T">.
        /// </summary>
        /// <param name="entity"><"T"> to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Delete <"T">. Not permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted.</param>
        void Delete(T entity);

        /// <summary>
        /// Delete <"T"> permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted permanent.</param>
        void DeletePermanent(T entity);
    }
}
