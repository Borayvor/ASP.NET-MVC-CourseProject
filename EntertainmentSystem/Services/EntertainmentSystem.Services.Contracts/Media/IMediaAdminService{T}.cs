namespace EntertainmentSystem.Services.Contracts.Media
{
    using Common;
    using Data.Common.Models;

    public interface IMediaAdminService<T> : IBaseGetService<T>,
        IBaseCreateService<T>, IBaseUpdateService<T>,
        IBaseDeleteService<T>, IBaseAdminService<T>
        where T : IAuditInfo, IDeletableEntity
    {
    }
}
