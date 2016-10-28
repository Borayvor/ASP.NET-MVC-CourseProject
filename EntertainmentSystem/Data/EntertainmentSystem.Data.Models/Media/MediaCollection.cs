namespace EntertainmentSystem.Data.Models.Media
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class MediaCollection : BaseModelGuid
    {
        private ICollection<MediaContent> contents;

        public MediaCollection()
        {
            this.contents = new HashSet<MediaContent>();
        }

        [Required]
        [MinLength(GlobalConstants.MediaCollectionNameMinLength)]
        [MaxLength(GlobalConstants.MediaCollectionNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<MediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}
