﻿namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models.WordModels;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;
    using Services.Web;

    public class LanguagesController : Controller
    {
        private readonly ILanguagesService languages;
        private readonly IIdentifierProvider identifier;

        public LanguagesController(
            ILanguagesService languages,
            IIdentifierProvider identifier)
        {
            this.languages = languages;
            this.identifier = identifier;
        }

        public ActionResult LanguagesIndex()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Languages_Read([DataSourceRequest] DataSourceRequest request)
        {
            var languages = this.languages.GetAll()
                .To<LanguageViewModel>()
                .ToDataSourceResult(request);

            return this.Json(languages);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, LanguageInputModel language)
        {
            if (this.ModelState.IsValid)
            {
                var newId = 0;

                var entity = new Language
                {
                    Name = language.Name
                };

                this.languages.Add(entity);
                newId = entity.Id;
            }

            var wordsToDisplay = this.languages.GetAll()
                .To<LanguageViewModel>();

            return this.Json(wordsToDisplay.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, LanguageInputModel language)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.languages.GetById(this.identifier.EncodeId(language.Id));
                entity.Name = language.Name;

                this.languages.Update(entity);
            }

            return this.Json(new[] { language }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, Language language)
        {
            var languageToDelete = this.languages.GetById(this.identifier.EncodeId(language.Id));
            this.languages.Delete(languageToDelete);

            var languagesToDisplay = this.languages.GetAll()
                .To<LanguageViewModel>();

            return this.Json(languagesToDisplay.ToDataSourceResult(request, this.ModelState));
        }
    }
}
