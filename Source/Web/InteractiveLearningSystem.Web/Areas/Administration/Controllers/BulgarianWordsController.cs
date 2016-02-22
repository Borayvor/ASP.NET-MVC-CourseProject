namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Common;
    using Data.Models.WordModels.Bulgarian;
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

        [HttpGet]
        public ActionResult Index()
        {
            var words = this.words.GetAll().To<BulgarianWordViewModel>().ToList();

            var viewModel = new IndexViewModel
            {
                Words = words
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BulgarianWordInputModel model)
        {
            // TODO: Fix problems
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.words.Add(model.Name, model.Language.Id);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var word = this.words.GetById(id);

            if (word == null)
            {
                return this.HttpNotFound();
            }

            // TODO: Edit Not Work !
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BulgarianWordInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            // TODO: Edit Not Work !
            return this.View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(BulgarianWord word)
        {
            this.words.Delete(word);

            return this.RedirectToAction("Index");
        }
    }
}
