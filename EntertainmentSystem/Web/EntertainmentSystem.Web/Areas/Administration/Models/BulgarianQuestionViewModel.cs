namespace EntertainmentSystem.Web.Areas.Administration.Models
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianQuestionViewModel : IMapFrom<BulgarianQuestion>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public int WordId { get; set; }

        public string Word { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BulgarianQuestion, BulgarianQuestionViewModel>()
                .ForMember(x => x.Word, options => options.MapFrom(x => x.Word.Name));
        }
    }
}
