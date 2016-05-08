namespace EntertainmentSystem.Services.Data.Contracts
{
    using EntertainmentSystem.Data.Models.WordModels.Bulgarian;

    public interface IEnsureWordsService
    {
        BulgarianWord EnsureWord(string name);
    }
}
