namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;

    public interface IBulgarianWordService
    {
        BulgarianWord GetById(string id);

        IQueryable<BulgarianWord> GetRandomWords(int count);
    }
}
