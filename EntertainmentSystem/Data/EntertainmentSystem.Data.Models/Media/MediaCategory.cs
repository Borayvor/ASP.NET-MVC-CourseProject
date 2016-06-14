﻿namespace EntertainmentSystem.Data.Models.Media
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class MediaCategory : BaseModel<int>
    {
        private ICollection<MaediaContent> contents;

        public MediaCategory()
        {
            this.contents = new HashSet<MaediaContent>();
        }

        [Required]
        [MaxLength(500)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<MaediaContent> MaediaContents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }
    }
}