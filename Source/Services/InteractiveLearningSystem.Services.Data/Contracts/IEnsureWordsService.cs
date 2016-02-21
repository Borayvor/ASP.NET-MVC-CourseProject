namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;

    public interface IEnsureWordsService
    {
        BulgarianWord EnsureWord(string name);
    }
}
