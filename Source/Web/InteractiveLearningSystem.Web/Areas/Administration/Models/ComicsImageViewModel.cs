namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.Web.Mvc;

    public class ComicsImageViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public byte[] Image { get; set; }
    }
}
