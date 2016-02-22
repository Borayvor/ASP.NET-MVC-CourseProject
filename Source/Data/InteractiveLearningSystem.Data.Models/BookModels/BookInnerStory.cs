namespace InteractiveLearningSystem.Data.Models.BookModels
{
    using System.ComponentModel.DataAnnotations;

    public class BookInnerStory
    {
        [Range(0, int.MaxValue)]
        public int? Position { get; set; }

        [MaxLength(10000)]
        public string Content { get; set; }

        public int BookStoryId { get; set; }

        public virtual BookStory BookStory { get; set; }
    }
}
