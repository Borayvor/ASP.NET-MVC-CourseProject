namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using Services.Contracts.Media.Admin;
    using ViewModels;
    using Web.ViewModels.Media;

    public class AdminMediaContentController : AdminController
    {
        private readonly IAdminMediaContentService adminContentService;
        private readonly IMediaCategoryService categoryService;
        private readonly IMediaCollectionService collectionService;

        public AdminMediaContentController(
            IAdminMediaContentService adminContentService,
            IMediaCategoryService categoryService,
            IMediaCollectionService collectionService)
        {
            this.adminContentService = adminContentService;
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
            var data = this.adminContentService
                .GetAllWithDeleted()
                .To<AdminMediaContentViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, AdminMediaContentEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.adminContentService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.adminContentService.Update(entity);

                var viewModel = this.Mapper.Map<AdminMediaContentViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestroyPermanent([DataSourceRequest]DataSourceRequest request, AdminMediaContentViewModel model)
        {
            // TODO: implement - delete files from cdn
            if (model != null)
            {
                var entity = this.adminContentService.GetById(model.Id);

                this.adminContentService.DeletePermanent(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
