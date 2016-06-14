namespace EntertainmentSystem.Services.Data.MediaServices.Contracts
{
    using System;
    using System.Linq;
    using EntertainmentSystem.Data.Models.Media;

    public interface IMaediaContentService
    {
        IQueryable<MaediaContent> GetAll();

        MaediaContent GetById(Guid id);

        void Create(MaediaContent content);

        void Update(MaediaContent content);

        void Delete(MaediaContent content);
    }
}
