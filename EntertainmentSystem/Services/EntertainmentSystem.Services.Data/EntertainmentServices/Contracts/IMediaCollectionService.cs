namespace EntertainmentSystem.Services.Data.EntertainmentServices.Contracts
{
    using System;
    using System.Linq;
    using EntertainmentSystem.Data.Models.Entertainment;

    public interface IMediaCollectionService
    {
        IQueryable<MediaCollection> GetAll();

        MediaCollection GetById(Guid id);

        void Create(MediaCollection collection);

        void Update(MediaCollection collection);

        void Delete(MediaCollection collection);
    }
}
