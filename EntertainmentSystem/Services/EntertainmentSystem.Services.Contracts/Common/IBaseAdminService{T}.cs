namespace EntertainmentSystem.Services.Contracts.Common
{
    using System.Linq;
    using Data.Common.Models;

    public interface IBaseAdminService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Get all <"T">. With ordinary deleted.
        /// </summary>
        /// <returns><"T"> as queryable.</returns>
        IQueryable<T> GetAllWithDeleted();

        /// <summary>
        /// Delete <"T"> permanent.
        /// </summary>
        /// <param name="entity"><"T"> to be deleted permanent.</param>
        void DeletePermanent(T entity);
    }
}
