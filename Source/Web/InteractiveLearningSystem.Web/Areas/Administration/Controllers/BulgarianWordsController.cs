namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Models;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class BulgarianWordsController : BaseController
    {
        private readonly IBulgarianWordService words;

        public BulgarianWordsController(IBulgarianWordService words)
        {
            this.words = words;
        }

        public ActionResult Words()
        {
            var words =
                this.Cache.Get(
                    "words",
                    () => this.words.GetAll().To<BulgarianWordViewModel>().ToList(),
                    30 * 60);

            var viewModel = new IndexViewModel
            {
                Words = words
            };

            return this.View(viewModel);
        }
    }
}
