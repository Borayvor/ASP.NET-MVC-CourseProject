namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using InteractiveLearningSystem.Data.Models.WordModels.Bulgarian;

    public interface IEnsureWordsService
    {
        BulgarianWord EnsureWord(string name);
    }
}
