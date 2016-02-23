namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianWordViewModel : IMapFrom<BulgarianWord>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BulgarianWord, BulgarianWordViewModel>()
                .ForMember(x => x.Language, options => options.MapFrom(x => x.Language.Name));
        }
    }
}
