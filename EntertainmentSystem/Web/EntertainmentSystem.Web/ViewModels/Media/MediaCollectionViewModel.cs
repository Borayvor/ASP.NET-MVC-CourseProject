namespace EntertainmentSystem.Web.ViewModels.Media
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models.Media;
    using Infrastructure.Mapping;

    public class MediaCollectionViewModel : BaseViewModel<Guid>, IMapFrom<MediaCollection>
    {
        [Display(Name = "Collection name")]
        public string Name { get; set; }
    }
}
