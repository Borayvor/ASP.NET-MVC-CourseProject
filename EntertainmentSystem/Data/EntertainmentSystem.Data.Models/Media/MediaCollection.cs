namespace EntertainmentSystem.Data.Models.Media
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class MediaCollection : BaseModelGuid
    {
        private ICollection<MediaContent> contents;

        public MediaCollection()
        {
            this.contents = new HashSet<MediaContent>();
        }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<MediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}
