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
            switch (controllerName)
            {
                case HtmlConstants.MediaMusicControllerName:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<MusicController>(c => c.Index());
                        }

                        return this.RedirectToAction<MusicController>(c => c.SearchByTitle(model.SearchText));
                    }

                case HtmlConstants.MediaPicturesControllerName:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<PicturesController>(c => c.Index());
                        }

                        return this.RedirectToAction<PicturesController>(c => c.SearchByTitle(model.SearchText));
                    }

                case HtmlConstants.MediaVideosControllerName:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<VideosController>(c => c.Index());
                        }

                        return this.RedirectToAction<VideosController>(c => c.SearchByTitle(model.SearchText));
                    }

                default:
                    {
                        throw new ArgumentException("Invalid media title !");
                    }
            }
        }
    }
}
