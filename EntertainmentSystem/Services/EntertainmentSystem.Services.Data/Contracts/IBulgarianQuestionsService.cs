namespace EntertainmentSystem.Services.Data.Contracts
{
    using System.Linq;
    using EntertainmentSystem.Data.Models.WordModels.Bulgarian;

    public interface IBulgarianQuestionsService
    {
        BulgarianQuestion GetById(string id);

        IQueryable<BulgarianQuestion> GetAll();

        void Add(BulgarianQuestion question);

        void Update(BulgarianQuestion question);

        void Delete(BulgarianQuestion question);
    }
}
