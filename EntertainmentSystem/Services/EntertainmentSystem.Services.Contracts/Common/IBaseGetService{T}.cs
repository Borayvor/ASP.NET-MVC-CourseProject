namespace EntertainmentSystem.Services.Contracts.Common
{
    using System.Linq;
    using Data.Common.Models;

    public interface IBaseGetService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Get all <"T">. Without ordinary deleted.
        /// </summary>
        /// <returns><"T"> as queryable.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Gets the <"T"> by id.
        /// </summary>
        /// <param name="id">The id of the <"T"> to get.</param>
        T GetById(object id);
    }
}
