namespace EntertainmentSystem.Data.Models.MoveModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class MoveCategory : BaseModel<int>
    {
        private ICollection<Move> moves;

        public MoveCategory()
        {
            this.moves = new HashSet<Move>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Move> Moves
        {
            get { return this.moves; }
            set { this.moves = value; }
        }
    }
}
