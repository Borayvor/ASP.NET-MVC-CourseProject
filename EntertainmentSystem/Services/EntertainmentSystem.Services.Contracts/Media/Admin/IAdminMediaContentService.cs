namespace EntertainmentSystem.Services.Contracts.Media.Admin
{
    using Common;
    using Data.Models.Media;

    public interface IAdminMediaContentService
        : IMediaContentService, IBaseAdminService<MediaContent>
    {
    }
}
