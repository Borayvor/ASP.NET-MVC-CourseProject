namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<BulgarianWordViewModel> Words { get; set; }
    }
}