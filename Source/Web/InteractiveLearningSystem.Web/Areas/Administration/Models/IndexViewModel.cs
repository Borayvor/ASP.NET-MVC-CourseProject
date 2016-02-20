namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<WordViewModel> Words { get; set; }
    }
}