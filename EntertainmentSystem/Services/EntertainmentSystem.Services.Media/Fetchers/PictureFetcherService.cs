﻿namespace EntertainmentSystem.Services.Media.Fetchers
{
    using System.Linq;
    using Contracts.Media;
    using Contracts.Media.Fetchers;
    using Data.Models.Media;

    public class PictureFetcherService : IPictureFetcherService
    {
        private readonly IMaediaContentService contents;

        public PictureFetcherService(IMaediaContentService contents)
        {
            this.contents = contents;
        }

        public IQueryable<MediaContent> GetAll()
        {
            return this.contents.GetAll()
                .Where(c => c.ContentType == ContentType.Picture);
        }
    }
}