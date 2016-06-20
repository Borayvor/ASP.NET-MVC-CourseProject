namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Web.Mvc;

    public abstract class AdminBaseViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
    }
}
