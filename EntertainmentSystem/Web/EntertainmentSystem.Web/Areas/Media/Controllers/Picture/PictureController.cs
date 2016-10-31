﻿namespace EntertainmentSystem.Web.Areas.Media.Controllers.Picture
{
    using System;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Contracts.Media.Fetchers;
    using ViewModels;

    public class PictureController : MediaController
    {
        private readonly IPictureFetcherService pictureService;

        public PictureController(IPictureFetcherService pictureService)
        {
            this.pictureService = pictureService;
        }

        public ActionResult Index()
        {
            return this.ConditionalActionResult(
                () => this.pictureService
                .All()
                .To<MediaBaseViewModel>(),
                (content) => this.View(content));
        }

        public ActionResult SearchByTitle(string search)
        {
            return this.ConditionalActionResult(
                () => this.pictureService
                .AllByTitle(search)
                .To<MediaBaseViewModel>(),
                (content) => this.View("Index", content));
        }

        public ActionResult PictureDetails(Guid id)
        {
            return this.ConditionalActionResult(
                () => this.Mapper.Map<MediaDetailsViewModel>(this.pictureService.GetById(id)),
                (content) => this.View(content));
        }
    }
}
