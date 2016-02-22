namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using InteractiveLearningSystem.Data.Models.WordModels.Bulgarian;

    public interface IBulgarianWordService
    {
        BulgarianWord GetById(string id);

        BulgarianWord GetByName(string name);

        IQueryable<BulgarianWord> GetAll();

        void Add(string name, int languageId);

        void Delete(BulgarianWord word);
    }
}
