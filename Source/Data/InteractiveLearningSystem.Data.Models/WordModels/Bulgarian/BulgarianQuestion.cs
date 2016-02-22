namespace InteractiveLearningSystem.Data.Models.WordModels.Bulgarian
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class BulgarianQuestion : BaseModel<int>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Name { get; set; }

        public int WordId { get; set; }

        public virtual BulgarianWord Word { get; set; }
    }
}
