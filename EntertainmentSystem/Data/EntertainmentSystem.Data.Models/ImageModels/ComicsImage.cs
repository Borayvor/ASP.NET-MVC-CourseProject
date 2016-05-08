namespace EntertainmentSystem.Data.Models.ImageModels
{
    using System.ComponentModel.DataAnnotations;
    using ComicsModels;
    using Common.Models;

    public class ComicsImage : BaseModel<int>
    {
        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string FileFullName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string ContentType { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        public int ComicsId { get; set; }

        public virtual Comics Comics { get; set; }
    }
}
