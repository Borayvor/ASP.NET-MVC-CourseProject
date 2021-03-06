﻿namespace EntertainmentSystem.Data.Common.Repositories
{
    using System.Linq;

    using Models;

    public interface IDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeletePermanent(T entity);

        void Save();
    }
}
