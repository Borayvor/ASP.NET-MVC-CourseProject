namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    using Data.Models.Forum;
    using Infrastructure.Mapping;
    using Web.ViewModels;

    public class TagViewModel : BaseViewModel<int>, IMapFrom<Tag>
    {
        public string Name { get; set; }
    }
}
