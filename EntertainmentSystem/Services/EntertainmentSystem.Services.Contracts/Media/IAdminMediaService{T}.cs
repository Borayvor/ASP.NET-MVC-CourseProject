namespace EntertainmentSystem.Services.Contracts.Media
{
    using Data.Common.Models;

    public interface IAdminMediaService<T> where T : IAuditInfo, IDeletableEntity
    {
    }
}
