namespace EntertainmentSystem.Web.Areas.Forum.ViewModels
{
    public class PostCommentsPageViewModel
    {
        public PostViewModel Post { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
