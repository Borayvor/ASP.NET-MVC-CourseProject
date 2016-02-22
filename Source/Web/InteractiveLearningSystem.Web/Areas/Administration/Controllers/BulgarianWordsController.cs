namespace InteractiveLearningSystem.Web.Areas.Administration.Controllers
{
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

        public BulgarianWordsController(IBulgarianWordService words)
        {
            this.words = words;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BulgarianWords_Read([DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(this.words.GetAll()
                .To<BulgarianWordViewModel>()
                .ToDataSourceResult(request));
        }
    }
}
