namespace EntertainmentSystem.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    public class SearchViewModel
    {
        [DataType(DataType.Text)]
        [MaxLength(250)]
        public string SearchText { get; set; }
    }
}
