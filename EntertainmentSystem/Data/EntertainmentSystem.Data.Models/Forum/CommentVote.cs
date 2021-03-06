﻿namespace EntertainmentSystem.Data.Models.Forum
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class CommentVote : BaseModel<int>
    {
        public VoteType Value { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public Guid? CommentId { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
