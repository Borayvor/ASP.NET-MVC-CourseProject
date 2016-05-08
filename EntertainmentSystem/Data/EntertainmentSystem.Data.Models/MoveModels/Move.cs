namespace EntertainmentSystem.Data.Models.MoveModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Move : BaseModel<int>
    {
        [Required]
        [Index]
        [MinLength(1)]
        [MaxLength(60)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(600)]
        public string Url { get; set; }

        public int CategoryId { get; set; }

        public virtual MoveCategory Category { get; set; }
    }
}
