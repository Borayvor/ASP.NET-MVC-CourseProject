namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;
    using Services.Web;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class BulgarianWordsController : BaseController
    {
        private readonly IBulgarianWordService words;
        private readonly IIdentifierProvider identifier;

        public BulgarianWordsController(
            IBulgarianWordService words,
            IIdentifierProvider identifier)
        {
            this.words = words;
            this.identifier = identifier;
        }

        public ActionResult BulgarianWordsIndex()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult BulgarianWords_Read([DataSourceRequest] DataSourceRequest request)
        {
            var words = this.words.GetAll()
                .To<BulgarianWordViewModel>()
                .ToDataSourceResult(request);

            return this.Json(words);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BulgarianWordInputModel word)
        {
            if (this.ModelState.IsValid)
            {
                var newId = 0;

                var entity = new BulgarianWord
                {
                    Name = word.Name,
                    LanguageId = 1
                };

                this.words.Add(entity);
                newId = entity.Id;
            }

            var wordsToDisplay = this.words.GetAll()
                .To<BulgarianWordViewModel>();

            return this.Json(wordsToDisplay.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, BulgarianWordInputModel word)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.words.GetById(this.identifier.EncodeId(word.Id));
                entity.Name = word.Name;

                this.words.Update(entity);
            }

            return this.Json(new[] { word }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, BulgarianWord word)
        {
            var wordToDelete = this.words.GetById(this.identifier.EncodeId(word.Id));
            this.words.Delete(wordToDelete);

            var wordsToDisplay = this.words.GetAll()
                .To<BulgarianWordViewModel>();

            return this.Json(wordsToDisplay.ToDataSourceResult(request, this.ModelState));
        }
    }
}
