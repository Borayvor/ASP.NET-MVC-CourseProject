namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Forum;
    using Infrastructure.Mapping;

    public class PostCreateViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

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

        [UIHint("DropDownListPostCategories")]
        public PostCategory Category { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
