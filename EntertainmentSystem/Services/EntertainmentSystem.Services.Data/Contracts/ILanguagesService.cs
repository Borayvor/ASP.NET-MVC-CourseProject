namespace EntertainmentSystem.Services.Data.Contracts
{
    using System.Linq;
    using EntertainmentSystem.Data.Models.WordModels;

    public interface ILanguagesService
    {
        Language GetById(string id);

        Language GetByName(string name);

        IQueryable<Language> GetAll();

        void Add(Language language);

        void Update(Language language);

        void Delete(Language language);
    }
}
