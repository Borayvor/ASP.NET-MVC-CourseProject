namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using Data.Models.WordModels.Bulgarian;
    using Infrastructure.Mapping;

    public class BulgarianWordViewModel : IMapFrom<BulgarianWord>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
