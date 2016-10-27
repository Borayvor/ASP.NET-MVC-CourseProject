namespace EntertainmentSystem.Web.Areas.Moderators.Controllers.Media
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels.Media;

    public class ModeratorMediaContentController : ModeratorController
    {
        private readonly IMediaContentService contentService;
        private readonly IMediaCategoryService categoryService;
        private readonly IMediaCollectionService collectionService;

        public ModeratorMediaContentController(
            IMediaContentService contentService,
            IMediaCategoryService categoryService,
            IMediaCollectionService collectionService)
        {
            this.contentService = contentService;
            this.categoryService = categoryService;
            this.collectionService = collectionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = this.categoryService
                .GetAll()
                .AsQueryable()
                .OrderBy(c => c.Name)
                .To<MediaCategoryEditViewModel>()
                .ToList();

            var collections = this.collectionService
                .GetAll()
                .AsQueryable()
                .OrderBy(c => c.Name)
                .To<MediaCollectionEditViewModel>()
                .ToList();

            this.ViewBag.Categories = new SelectList(categories, "Id", "Name");
            this.ViewBag.Collections = new SelectList(collections, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.contentService
                .GetAll()
                .To<MediaContentViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MediaContentEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.contentService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.contentService.Update(entity);

                var viewModel = this.Mapper.Map<MediaContentViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, MediaContentViewModel model)
        {
            if (model != null)
            {
                var entity = this.contentService.GetById(model.Id);

                this.contentService.Delete(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
