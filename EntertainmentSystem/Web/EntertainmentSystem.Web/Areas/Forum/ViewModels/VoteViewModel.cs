namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using System.Web.Mvc;
    using Data.Models;
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class VoteViewModel : BaseViewModel<int>, IMapFrom<Vote>, IMapTo<Vote>
    {
        public VoteType Value { get; set; }

        [HiddenInput(DisplayValue = false)]
        public ApplicationUser Author { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Post Post { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Comment Comment { get; set; }
    }
}
