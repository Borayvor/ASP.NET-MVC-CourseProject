namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models.Forum;
    using Infrastructure.Filters;
    using Infrastructure.Mapping;

    public class PostCreateViewModel : IMapFrom<Post>, IMapTo<Post>
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

        [UIHint("DropDownListPostCategories")]
        [Display(Name = "Category")]
        public Guid CategoryId { get; set; }

        [Required]
        [ValidatePostTagsCount(2)]
        public string Tags { get; set; }
    }
}
