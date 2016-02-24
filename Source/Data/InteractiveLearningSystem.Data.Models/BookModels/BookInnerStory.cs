namespace InteractiveLearningSystem.Data.Models.BookModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class BookInnerStory : BaseModel<int>
    {
        [Range(0, int.MaxValue)]
        public int? Position { get; set; }

        [MaxLength(10000)]
        public string Content { get; set; }

        public int BookStoryId { get; set; }

        public virtual BookStory BookStory { get; set; }
    }
}
