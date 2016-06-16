namespace EntertainmentSystem.Web.Areas.Administration.ViewModels
{
    using System;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCategoryAdminViewModel : AdminViewModel, IMapFrom<MediaCategory>
    {
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
