namespace InteractiveLearningSystem.Data.Models.MoveModels
{
    using System.Collections.Generic;
    using Common.Models;

    public class MoveCategory : BaseModel<int>
    {
        private ICollection<Move> moves;

        public MoveCategory()
        {
            this.moves = new HashSet<Move>();
        }

        public string Name { get; set; }

        public virtual ICollection<Move> Moves
        {
            get { return this.moves; }
            set { this.moves = value; }
        }
    }
}
