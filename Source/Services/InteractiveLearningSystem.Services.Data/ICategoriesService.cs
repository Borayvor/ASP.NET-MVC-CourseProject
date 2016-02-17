namespace InteractiveLearningSystem.Services.Data
{
    using System.Linq;

    using InteractiveLearningSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
