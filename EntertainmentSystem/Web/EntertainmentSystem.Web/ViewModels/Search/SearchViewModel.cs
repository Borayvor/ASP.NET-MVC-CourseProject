namespace EntertainmentSystem.Web.ViewModels.Search
{
    using System.ComponentModel.DataAnnotations;

    public class SearchViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "Search text must be at least 1 characters !")]
        [MaxLength(250)]
        public string SearchText { get; set; }
    }
}
