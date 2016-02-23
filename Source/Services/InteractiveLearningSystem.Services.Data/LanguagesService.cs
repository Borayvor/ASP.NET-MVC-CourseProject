namespace InteractiveLearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using InteractiveLearningSystem.Data.Common;
    using InteractiveLearningSystem.Data.Models.WordModels;
    using Web;

    public class LanguagesService : ILanguagesService
    {
        private readonly IDbRepository<Language> languages;
        private readonly IIdentifierProvider identifierProvider;

        public LanguagesService(IDbRepository<Language> languages, IIdentifierProvider identifierProvider)
        {
            this.languages = languages;
            this.identifierProvider = identifierProvider;
        }

        public Language GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var language = this.languages.GetById(intId);

            return language;
        }

        public Language GetByName(string name)
        {
            var language = this.languages.All().FirstOrDefault(x => x.Name == name);

            return language;
        }

        public IQueryable<Language> GetAll()
        {
            return this.languages.All().OrderBy(x => x.Name);
        }

        public void Add(Language language)
        {
            this.languages.Add(language);
            this.languages.Save();
        }

        public void Update(Language language)
        {
            this.languages.Update(language);
            this.languages.Save();
        }

        public void Delete(Language language)
        {
            this.languages.Delete(language);
            this.languages.Save();
        }
    }
}
