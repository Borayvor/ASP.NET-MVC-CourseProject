namespace EntertainmentSystem.Web.Controllers.Search
{
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Areas.Media.Controllers.Music;
    using Areas.Media.Controllers.Picture;
    using Areas.Media.Controllers.Video;
    using ViewModels.Search;

    public class SearchController : BaseController
    {
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchMusic(SearchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction<MusicController>(c => c.Index());
            }

            return this.RedirectToAction<MusicController>(c => c.SearchByTitle(model.SearchText));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchPictures(SearchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction<PictureController>(c => c.Index());
            }

            return this.RedirectToAction<PictureController>(c => c.SearchByTitle(model.SearchText));
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchVideos(SearchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction<VideoController>(c => c.Index());
            }

            return this.RedirectToAction<VideoController>(c => c.SearchByTitle(model.SearchText));
        }
    }
}
