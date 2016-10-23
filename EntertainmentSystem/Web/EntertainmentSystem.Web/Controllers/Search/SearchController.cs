namespace EntertainmentSystem.Web.Controllers.Search
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
    using Areas.Media.Controllers.Music;
    using Areas.Media.Controllers.Picture;
    using Areas.Media.Controllers.Video;
    using Common.Constants;
    using ViewModels.Search;

    public class SearchController : BaseController
    {
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchMedia(string viewTitle, SearchViewModel model)
        {
            switch (viewTitle)
            {
                case HtmlConstants.MediaMusicHomeTitle:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<MusicController>(c => c.Index());
                        }

                        return this.RedirectToAction<MusicController>(c => c.SearchByTitle(model.SearchText));
                    }

                case HtmlConstants.MediaPicturesHomeTitle:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<PictureController>(c => c.Index());
                        }

                        return this.RedirectToAction<PictureController>(c => c.SearchByTitle(model.SearchText));
                    }

                case HtmlConstants.MediaVideosHomeTitle:
                    {
                        if (!this.ModelState.IsValid)
                        {
                            return this.RedirectToAction<VideoController>(c => c.Index());
                        }

                        return this.RedirectToAction<VideoController>(c => c.SearchByTitle(model.SearchText));
                    }

                default:
                    {
                        throw new ArgumentException("Invalid media title !");
                    }
            }
        }
    }
}
