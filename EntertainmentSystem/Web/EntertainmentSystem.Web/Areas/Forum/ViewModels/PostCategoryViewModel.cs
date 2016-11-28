namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Web.Mvc;
    using Data.Models.Forum;
    using Infrastructure.Mapping;

    public class PostCategoryViewModel : IMapFrom<PostCategory>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
