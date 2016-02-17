namespace InteractiveLearningSystem.Services.Data
{
    using System.Linq;

    using InteractiveLearningSystem.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
