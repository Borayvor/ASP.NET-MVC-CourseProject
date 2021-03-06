﻿namespace EntertainmentSystem.Web.Areas.Media.Controllers.Video
{
    using System;
    using System.Web.Mvc;
    using Common.Constants;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class VideosController : MediaController
    {
        private readonly IVideoFetcherService videoService;

        public VideosController(IVideoFetcherService videoService)
        {
            this.videoService = videoService;
            this.ViewBag.ControllerName = HtmlConstants.MediaVideosControllerName;
        }

        [HttpGet]
        public ActionResult Index(
            int? page,
            string search = GlobalConstants.StringEmpty,
            string collectionName = GlobalConstants.StringEmpty,
            string categoryName = GlobalConstants.StringEmpty)
        {
            int currentPage = page ?? GlobalConstants.MediaStartPage;

            return this.ConditionalActionResult(
                () => this.GetMediaFilesPage<MediaBaseViewModel>(
                    this.videoService,
                    currentPage,
                    search,
                    collectionName,
                    categoryName),
                (content) => this.View(content));
        }

        [HttpGet]
        public ActionResult VideoDetails(Guid id)
        {
            return this.ConditionalActionResult(
                () => this.Mapper.Map<MediaDetailsViewModel>(this.videoService.GetById(id)),
                (content) => this.View(content));
        }
    }
}
