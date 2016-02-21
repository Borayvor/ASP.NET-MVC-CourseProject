namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models.CrosswordModels.Bulgarian;
    using Infrastructure.Mapping;
    using Services.Web;

    public class BulgarianWordViewModel : IMapFrom<BulgarianWord>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(60)]
        [RegularExpression(@"\b[а-яА-Я]+\b", ErrorMessage = "Думата трябва да съдържа само Български букви !")]
        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();

                return string.Format("/Questions/{0}", identifier.EncodeId(this.Id));
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BulgarianWord, BulgarianWordViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name));
        }
    }
}