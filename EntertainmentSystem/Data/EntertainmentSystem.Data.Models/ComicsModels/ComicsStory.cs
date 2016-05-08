namespace EntertainmentSystem.Data.Models.ComicsModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using ImageModels;

    public class ComicsStory : BaseModel<int>
    {
        private ICollection<ComicsImage> comicsImages;

        public ComicsStory()
        {
            this.comicsImages = new HashSet<ComicsImage>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public int ComicsId { get; set; }

        public virtual Comics Comics { get; set; }

        public virtual ICollection<ComicsImage> ComicsImages
        {
            get { return this.comicsImages; }
            set { this.comicsImages = value; }
        }
    }
}
