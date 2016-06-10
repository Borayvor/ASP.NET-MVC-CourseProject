namespace EntertainmentSystem.Data.Models.Entertainment
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class MediaCategory : BaseModelGuid
    {
        private ICollection<MaediaContent> contents;

        public MediaCategory()
        {
            this.contents = new HashSet<MaediaContent>();
        }

        [Required]
        [MaxLength(512)]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        public virtual ICollection<MaediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}
