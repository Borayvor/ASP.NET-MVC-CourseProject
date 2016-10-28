namespace EntertainmentSystem.Data.Models.Media
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using EntertainmentSystem.Common.Constants;

    public class MediaCategory : BaseModelGuid
    {
        private ICollection<MediaContent> contents;

        public MediaCategory()
        {
            this.contents = new HashSet<MediaContent>();
        }

        [Required]
        [MinLength(GlobalConstants.MediaCategoryNameMinLength)]
        [MaxLength(GlobalConstants.MediaCategoryNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<MediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}
