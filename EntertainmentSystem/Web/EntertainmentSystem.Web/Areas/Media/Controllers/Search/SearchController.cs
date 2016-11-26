namespace EntertainmentSystem.Web.Areas.Media.Controllers.Search
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Common.Constants;
    using Music;
    using Picture;
    using Video;
    using Web.Controllers;
    using Web.ViewModels.Search;

    [Authorize]
    [ValidateAntiForgeryToken]
    public class SearchController : BaseController
    {
        [HttpPost]
        public ActionResult SearchMedia(string controllerName, SearchViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException("Invalid search data !");
            }

            switch (controllerName)
            {
                case HtmlConstants.MediaMusicControllerName:
                    {
                        return this.RedirectToAction<MusicController>(c => c.Index(null, model.SearchText, null, null));
                    }

                case HtmlConstants.MediaPicturesControllerName:
                    {
                        return this.RedirectToAction<PicturesController>(c => c.Index(null, model.SearchText, null, null));
                    }

                case HtmlConstants.MediaVideosControllerName:
                    {
                        return this.RedirectToAction<VideosController>(c => c.Index(null, model.SearchText, null, null));
                    }

                default:
                    {
                        throw new ArgumentException("Invalid media title !");
                    }
            }
        }
    }
}
