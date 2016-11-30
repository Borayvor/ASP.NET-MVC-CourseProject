namespace EntertainmentSystem.Services.Contracts.Common
{
    using System.Linq;
    using Data.Common.Models;
    using EntertainmentSystem.Common.Enums;

    public interface IBaseGetService<T, I> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Get all <"T">. Without ordinary deleted.
        /// </summary>
        /// <returns><"T"> as queryable.</returns>
        IQueryable<T> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn);

        /// <summary>
        /// Gets the <"T"> by id.
        /// </summary>
        /// <param name="id">The id of the <"T"> as <"I"> to get.</param>
        /// <returns>Return <"T"> with id <"I"></returns>
        T GetById(I id);
    }
}
