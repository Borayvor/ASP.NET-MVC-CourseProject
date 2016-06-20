namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Web.Mvc;

    public abstract class AdminBaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
