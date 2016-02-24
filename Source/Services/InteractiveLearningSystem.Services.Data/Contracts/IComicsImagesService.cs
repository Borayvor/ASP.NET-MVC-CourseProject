namespace InteractiveLearningSystem.Services.Data.Contracts
{
    using System.Linq;
    using InteractiveLearningSystem.Data.Models.ImageModels;

    public interface IComicsImagesService
    {
        ComicsImage GetById(string id);

        IQueryable<ComicsImage> GetAll();

        void Add(ComicsImage image);

        void Update(ComicsImage image);

        void Delete(ComicsImage image);
    }
}
