namespace InteractiveLearningSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using InteractiveLearningSystem.Data.Common;
    using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;

    public class BulgarianWordService : IBulgarianWordService
    {
        private readonly IDbRepository<BulgarianWord> words;
        //private readonly IIdentifierProvider identifierProvider;

        public BulgarianWordService(IDbRepository<BulgarianWord> words)
        {
            this.words = words;
            //this.identifierProvider = identifierProvider;
        }

        public BulgarianWord GetById(string id)
        {
            //var intId = this.identifierProvider.DecodeId(id);
            var word = this.words.GetById(1);

            return word;
        }

        public IQueryable<BulgarianWord> GetRandomWords(int count)
        {
            return this.words.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
