namespace EntertainmentSystem.Data.Models.CrosswordModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Crossword : BaseModel<int>
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [Range(2, 200)]
        public int NumberOfWords { get; set; }
    }
}
