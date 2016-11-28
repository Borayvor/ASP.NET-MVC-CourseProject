namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class PostCreateViewModel : BaseViewModel<Guid>,
        IMapFrom<Post>, IMapTo<Post>
    {
        [Required]
        [MinLength(GlobalConstants.PostTitleMinLength)]
        [MaxLength(GlobalConstants.PostTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(GlobalConstants.PostContentMinLength)]
        [MaxLength(GlobalConstants.PostContentMaxLength)]
        [DataType(DataType.MultilineText)]
        [HiddenInput(DisplayValue = false)]
        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public PostCategory Category { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
