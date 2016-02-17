namespace InteractiveLearningSystem.Web.ViewModels.Home
{
    using InteractiveLearningSystem.Data.Models;
    using InteractiveLearningSystem.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
