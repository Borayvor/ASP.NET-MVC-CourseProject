namespace InteractiveLearningSystem.Data.Models.BookModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ImageModels;

    public class Book
    {
        private ICollection<BookImage> bookImages;

        public Book()
        {
            this.bookImages = new HashSet<BookImage>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public virtual ICollection<BookImage> BookImages
        {
            get { return this.bookImages; }
            set { this.bookImages = value; }
        }
    }
}
