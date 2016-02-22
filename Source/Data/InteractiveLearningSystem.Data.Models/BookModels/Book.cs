﻿namespace InteractiveLearningSystem.Data.Models.BookModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using ImageModels;

    public class Book
    {
        private ICollection<BookStory> bookStories;

        public Book()
        {
            this.bookStories = new HashSet<BookStory>();
        }

        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        public virtual ICollection<BookStory> BookStories
        {
            get { return this.bookStories; }
            set { this.bookStories = value; }
        }
    }
}
