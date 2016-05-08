namespace EntertainmentSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common;
    using EntertainmentSystem.Data.Models.ImageModels;
    using Web;

    public class ComicsImagesService : IComicsImagesService
    {
        private readonly IDbRepository<ComicsImage> images;
        private readonly IIdentifierProvider identifierProvider;

        public ComicsImagesService(IDbRepository<ComicsImage> images, IIdentifierProvider identifierProvider)
        {
            this.images = images;
            this.identifierProvider = identifierProvider;
        }

        public ComicsImage GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var image = this.images.GetById(intId);

            return image;
        }

        public IQueryable<ComicsImage> GetAll()
        {
            return this.images.All().OrderBy(x => x.Id);
        }

        public void Add(ComicsImage image)
        {
            this.images.Add(image);
            this.images.Save();
        }

        public void Update(ComicsImage image)
        {
            this.images.Update(image);
            this.images.Save();
        }

        public void Delete(ComicsImage image)
        {
            this.images.Delete(image);
            this.images.Save();
        }
    }
}
