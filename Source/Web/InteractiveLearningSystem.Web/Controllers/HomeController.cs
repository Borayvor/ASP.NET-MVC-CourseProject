namespace InteractiveLearningSystem.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        //private readonly IJokesService jokes;
        //private readonly ICategoriesService jokeCategories;

        //public HomeController(
        //    IJokesService jokes,
        //    ICategoriesService jokeCategories)
        //{
        //    this.jokes = jokes;
        //    this.jokeCategories = jokeCategories;
        //}

        public ActionResult Index()
        {

            return this.View();
        }
    }
}
