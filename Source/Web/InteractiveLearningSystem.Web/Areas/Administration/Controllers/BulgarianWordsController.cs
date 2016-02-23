namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class BulgarianWordsController : BaseController
    {
        private readonly IBulgarianWordService words;
        private readonly ILanguagesService languages;
        private readonly IBulgarianQuestionsService questions;

        public BulgarianWordsController(
            IBulgarianWordService words,
            ILanguagesService languages,
            IBulgarianQuestionsService questions)
        {
            this.words = words;
            this.languages = languages;
            this.questions = questions;
        }

        public ActionResult Index()
        {
            this.PopulateDropDowns();

            return this.View();
        }

        [HttpPost]
        public ActionResult BulgarianWords_Read([DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(this.words.GetAll()
                .To<BulgarianWordViewModel>()
                .ToDataSourceResult(request));
        }

        private void PopulateDropDowns()
        {
            var languages =
               this.languages.GetAll().To<LanguageViewModel>().OrderBy(x => x.Name);

            var questions =
               this.questions.GetAll().To<BulgarianQuestionViewModel>().OrderBy(x => x.Id);

            this.ViewData["languages"] = languages;
            this.ViewData["defaultLanguage"] = languages.First();
            this.ViewData["bulgarianQuestions"] = questions;
            this.ViewData["defaultBulgarianQuestion"] = questions.First();
        }
    }
}
