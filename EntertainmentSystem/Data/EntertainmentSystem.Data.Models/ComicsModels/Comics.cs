namespace EntertainmentSystem.Data.Models.ComicsModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Comics : BaseModel<int>
    {
        private ICollection<ComicsStory> comicsStories;

        public Comics()
        {
            this.comicsStories = new HashSet<ComicsStory>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public virtual ICollection<ComicsStory> ComicsStories
        {
            get { return this.comicsStories; }
            set { this.comicsStories = value; }
        }
    }
}
