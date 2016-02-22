namespace InteractiveLearningSystem.Data.Models.ComicsModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ImageModels;

    public class Comics
    {
        private ICollection<ComicsImage> comicsImages;

        public Comics()
        {
            this.comicsImages = new HashSet<ComicsImage>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public virtual ICollection<ComicsImage> ComicsImages
        {
            get { return this.comicsImages; }
            set { this.comicsImages = value; }
        }
    }
}
