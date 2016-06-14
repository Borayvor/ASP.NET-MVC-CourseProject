namespace EntertainmentSystem.Data.Models.Media
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class MediaCollection : BaseModel<int>
    {
        private ICollection<MaediaContent> contents;

        public MediaCollection()
        {
            this.contents = new HashSet<MaediaContent>();
        }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        public int? Number { get; set; }

        public virtual ICollection<MaediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}
