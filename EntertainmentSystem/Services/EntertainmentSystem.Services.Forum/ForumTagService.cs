namespace EntertainmentSystem.Services.Forum
{
    using System.Linq;
    using Common.Enums;
    using Contracts.Forum;
    using Data.Common.Repositories;
    using Data.Models.Forum;

    public class ForumTagService : IForumTagService
    {
        private readonly IDbRepository<Tag> tags;

        public ForumTagService(IDbRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> GetAll(EntityOrderBy orderBy = EntityOrderBy.CreateOn)
        {
            switch (orderBy)
            {
                case EntityOrderBy.NameProperty:
                    return this.tags.All().OrderBy(x => x.Name);
                default:
                    return this.tags.All().OrderByDescending(x => x.CreatedOn);
            }
        }

        public Tag GetById(int id)
        {
            return this.tags.GetById(id);
        }

        public Tag GetByName(string name)
        {
            return this.tags.All().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public void Create(Tag entity)
        {
            this.tags.Create(entity);
            this.tags.Save();
        }

        public void Update(Tag entity)
        {
            this.tags.Update(entity);
            this.tags.Save();
        }

        public void Delete(Tag entity)
        {
            this.tags.Delete(entity);
            this.tags.Save();
        }
    }
}
