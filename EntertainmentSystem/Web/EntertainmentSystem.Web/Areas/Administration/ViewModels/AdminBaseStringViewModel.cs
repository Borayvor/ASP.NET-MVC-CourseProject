namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System.Web.Mvc;

    public class AdminBaseStringViewModel : AdminBaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
    }
}
