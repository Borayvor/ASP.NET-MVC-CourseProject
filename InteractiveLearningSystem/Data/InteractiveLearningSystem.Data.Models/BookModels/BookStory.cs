namespace InteractiveLearningSystem.Data.Models.BookModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using ImageModels;

    public class BookStory : BaseModel<int>
    {
        private ICollection<BookImage> bookImages;
        private ICollection<BookInnerStory> bookInnerStories;

        public BookStory()
        {
            this.bookImages = new HashSet<BookImage>();
            this.bookInnerStories = new HashSet<BookInnerStory>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual ICollection<BookImage> BookImages
        {
            get { return this.bookImages; }
            set { this.bookImages = value; }
        }

        public virtual ICollection<BookInnerStory> BookInnerStories
        {
            get { return this.bookInnerStories; }
            set { this.bookInnerStories = value; }
        }
    }
}
