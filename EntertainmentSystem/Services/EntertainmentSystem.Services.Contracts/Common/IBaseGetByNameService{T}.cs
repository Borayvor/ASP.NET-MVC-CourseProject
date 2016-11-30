namespace EntertainmentSystem.Services.Contracts.Common
{
    using Data.Common.Models;

    public interface IBaseGetByNameService<T> where T : IAuditInfo, IDeletableEntity
    {
        /// <summary>
        /// Gets the <"T"> by name.
        /// </summary>
        /// <param name="name">The property 'Name' of the <"T"> to get.</param>
        /// <returns>Return <"T"> with prperty <"name">.</returns>
        T GetByName(string name);
    }
}
