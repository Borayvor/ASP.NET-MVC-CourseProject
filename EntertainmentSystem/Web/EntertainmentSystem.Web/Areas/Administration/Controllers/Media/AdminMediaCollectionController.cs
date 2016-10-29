namespace EntertainmentSystem.Web.Areas.Administration.Controllers.Media
{
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media.Admin;
    using ViewModels.Media;

    public class AdminMediaCollectionController : AdminController
    {
        private readonly IAdminMediaCollectionService collectionService;

        public AdminMediaCollectionController(IAdminMediaCollectionService collectionService)
        {
            this.collectionService = collectionService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaCollectionCreateViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<MediaCollection>(model);

                this.collectionService.Create(entity);
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.collectionService
                .GetAllWithDeleted()
                .To<MediaCollectionViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MediaCollectionEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.collectionService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.collectionService.Update(entity);

                var viewModel = this.Mapper.Map<MediaCollectionViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DestroyPermanent([DataSourceRequest]DataSourceRequest request, MediaCollectionViewModel model)
        {
            if (model != null)
            {
                var entity = this.collectionService.GetById(model.Id);

                this.collectionService.DeletePermanent(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
