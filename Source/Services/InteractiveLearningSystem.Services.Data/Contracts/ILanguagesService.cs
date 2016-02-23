namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using InteractiveLearningSystem.Data.Models.WordModels;

    public interface ILanguagesService
    {
        Language GetById(string id);

        Language GetByName(string name);

        IQueryable<Language> GetAll();

        void Add(Language language);

        void Update(Language language);

        void Delete(Language language);

        void SaveChanges();
    }
}
