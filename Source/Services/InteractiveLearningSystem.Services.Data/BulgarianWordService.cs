namespace InteractiveLearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using InteractiveLearningSystem.Data.Common;
    using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;
    using Web;

    public class BulgarianWordService : IBulgarianWordService
    {
        private readonly IDbRepository<BulgarianWord> words;
        private readonly IIdentifierProvider identifierProvider;

        public BulgarianWordService(IDbRepository<BulgarianWord> words, IIdentifierProvider identifierProvider)
        {
            this.words = words;
            this.identifierProvider = identifierProvider;
        }

        public BulgarianWord GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var word = this.words.GetById(intId);

            return word;
        }

        public BulgarianWord GetByName(string name)
        {
            var word = this.words.All().FirstOrDefault(x => x.Name == name);

            return word;
        }

        public IQueryable<BulgarianWord> GetAll()
        {
            return this.words.All().OrderBy(x => x.Name);
        }

        public void Add(string name, int languageId)
        {
            this.words.Add(new BulgarianWord() { Name = name, LanguageId = languageId });
            this.words.Save();
        }

        public void Delete(BulgarianWord word)
        {
            this.words.Delete(word);
            this.words.Save();
        }
    }
}
