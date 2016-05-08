namespace EntertainmentSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common;
    using EntertainmentSystem.Data.Models.WordModels.Bulgarian;

    public class EnsureWordsService : IEnsureWordsService
    {
        private readonly IDbRepository<BulgarianWord> words;

        public EnsureWordsService(IDbRepository<BulgarianWord> words)
        {
            this.words = words;
        }

        public BulgarianWord EnsureWord(string name)
        {
            var word = this.words.All().FirstOrDefault(x => x.Name == name);

            if (word != null)
            {
                return word;
            }

            word = new BulgarianWord { Name = name };
            this.words.Add(word);
            this.words.Save();

            return word;
        }
    }
}
