﻿namespace EntertainmentSystem.Services.Forum
{
    using System;
    using System.Linq;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly IDbRepository<PostCategory> categories;

        public ForumCategoryService(IDbRepository<PostCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<PostCategory> GetAll()
        {
            return this.categories.All();
        }

        public PostCategory GetById(Guid id)
        {
            return this.categories.GetById(id);
        }

        public void Create(PostCategory entity)
        {
            this.categories.Create(entity);
            this.categories.Save();
        }

        public void Update(PostCategory entity)
        {
            this.categories.Update(entity);
            this.categories.Save();
        }

        public void Delete(PostCategory entity)
        {
            this.categories.Delete(entity);
            this.categories.Save();
        }
    }
}