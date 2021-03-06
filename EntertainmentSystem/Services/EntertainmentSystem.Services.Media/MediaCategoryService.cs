﻿namespace EntertainmentSystem.Services.Media
{
    using System;
    using System.Linq;
    using Common.Enums;
    using Contracts.Media;
    using Data.Common.Repositories;
    using Data.Models.Media;

    public class MediaCategoryService : IMediaCategoryService
    {
        protected readonly IDbRepository<MediaCategory> categories;

        public MediaCategoryService(IDbRepository<MediaCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<MediaCategory> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn)
        {
            return this.categories.All().OrderByDescending(x => x.CreatedOn);
        }

        public MediaCategory GetById(Guid id)
        {
            return this.categories.GetById(id);
        }

        public MediaCategory GetByName(string name)
        {
            return this.categories.All().FirstOrDefault(x => x.Name == name);
        }

        public void Create(MediaCategory entity)
        {
            this.categories.Create(entity);
            this.categories.Save();
        }

        public void Update(MediaCategory entity)
        {
            this.categories.Update(entity);
            this.categories.Save();
        }

        public void Delete(MediaCategory entity)
        {
            this.categories.Delete(entity);
            this.categories.Save();
        }
    }
}
