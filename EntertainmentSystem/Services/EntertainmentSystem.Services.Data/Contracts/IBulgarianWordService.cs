namespace EntertainmentSystem.Services.Data.Contracts
{
    using System.Linq;
    using EntertainmentSystem.Data.Models.WordModels.Bulgarian;

    public interface IBulgarianWordService
    {
        BulgarianWord GetById(string id);

        BulgarianWord GetByName(string name);

        IQueryable<BulgarianWord> GetAll();

        void Add(BulgarianWord word);

        void Update(BulgarianWord word);

        void Delete(BulgarianWord word);
    }
}
