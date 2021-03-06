﻿namespace EntertainmentSystem.Web.Areas.Moderators.Controllers.Media
{
    using System.Web.Mvc;
    using Data.Models.Media;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts.Media;
    using ViewModels.Media;

    public class ModeratorMediaCategoryController : ModeratorController
    {
        private readonly IMediaCategoryService categoryService;

        public ModeratorMediaCategoryController(IMediaCategoryService categoryService)
        {
            this.categoryService = categoryService;
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
        public ActionResult Create(MediaCategoryCreateViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<MediaCategory>(model);

                this.categoryService.Create(entity);
            }

            return this.RedirectToActionPermanent("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.categoryService
                .GetAll()
                .To<MediaCategoryViewModel>()
                .ToDataSourceResult(request);

            return this.Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, MediaCategoryEditViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var entity = this.categoryService.GetById(model.Id);

                this.Mapper.Map(model, entity);

                this.categoryService.Update(entity);

                var viewModel = this.Mapper.Map<MediaCategoryViewModel>(entity);

                return this.Json(new[] { viewModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, MediaCategoryViewModel model)
        {
            if (model != null)
            {
                var entity = this.categoryService.GetById(model.Id);

                this.categoryService.Delete(entity);
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
