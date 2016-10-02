namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;

    public class AdminBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
