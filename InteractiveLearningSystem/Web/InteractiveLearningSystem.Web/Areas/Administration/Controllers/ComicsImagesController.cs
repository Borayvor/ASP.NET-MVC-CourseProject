namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models.ImageModels;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;
    using Services.Web;

    public class ComicsImagesController : Controller
    {
        private readonly IComicsImagesService images;
        private readonly IIdentifierProvider identifier;

        public ComicsImagesController(
            IComicsImagesService images,
            IIdentifierProvider identifier)
        {
            this.images = images;
            this.identifier = identifier;
        }

        public ActionResult ComicsImagesIndex()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IEnumerable<HttpPostedFileBase> comicsImages)
        {
            if (this.ModelState.IsValid)
            {
                foreach (var comicsImage in comicsImages)
                {
                    if (comicsImage != null && comicsImage.ContentLength > 0)
                    {
                        var currentImage = new ComicsImage
                        {
                            FileFullName = Path.GetFileName(comicsImage.FileName),
                            ContentType = comicsImage.ContentType
                        };

                        using (var reader = new BinaryReader(comicsImage.InputStream))
                        {
                            currentImage.Image = reader.ReadBytes(comicsImage.ContentLength);
                        }

                        this.images.Add(currentImage);
                    }
                }
            }

            return this.View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ComicsImageInputModel image)
        {
            // TODO Implement !
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, ComicsImage image)
        {
            // TODO Implement !
            return this.View();
        }
    }
}
