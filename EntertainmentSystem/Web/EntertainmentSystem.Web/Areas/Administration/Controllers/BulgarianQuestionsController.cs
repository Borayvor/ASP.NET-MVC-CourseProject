namespace EntertainmentSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Data.Contracts;
    using Services.Web;

    public class BulgarianQuestionsController : Controller
    {
        private readonly IBulgarianQuestionsService questions;
        private readonly IIdentifierProvider identifier;

        public BulgarianQuestionsController(
            IBulgarianQuestionsService questions,
            IIdentifierProvider identifier)
        {
            this.questions = questions;
            this.identifier = identifier;
        }

        public ActionResult BulgarianQuestionsIndex()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult BulgarianQuestions_Read([DataSourceRequest] DataSourceRequest request)
        {
            var questions = this.questions.GetAll()
                .To<BulgarianQuestionViewModel>()
                .ToDataSourceResult(request);

            return this.Json(questions);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BulgarianQuestionInputModel questions)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BulgarianQuestion
                {
                    Content = questions.Content,
                    WordId = questions.WordId
                };

                this.questions.Add(entity);
            }

            var wordsToDisplay = this.questions.GetAll()
                .To<BulgarianQuestionViewModel>();

            return this.Json(wordsToDisplay.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, BulgarianQuestionInputModel questions)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.questions.GetById(this.identifier.EncodeId(questions.Id));
                entity.Content = questions.Content;

                this.questions.Update(entity);
            }

            return this.Json(new[] { questions }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, BulgarianQuestion question)
        {
            var questionToDelete = this.questions.GetById(this.identifier.EncodeId(question.Id));
            this.questions.Delete(questionToDelete);

            var questionsToDisplay = this.questions.GetAll()
                .To<BulgarianQuestionViewModel>();

            return this.Json(questionsToDisplay.ToDataSourceResult(request, this.ModelState));
        }
    }
}
