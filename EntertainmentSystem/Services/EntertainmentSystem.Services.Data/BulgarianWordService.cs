﻿namespace EntertainmentSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using EntertainmentSystem.Data.Common.Repositories;
    using EntertainmentSystem.Data.Models.WordModels.Bulgarian;
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
            return this.words.All().OrderBy(x => x.Language.Name).ThenBy(x => x.Name);
        }

        public void Add(BulgarianWord word)
        {
            this.words.Add(word);
            this.words.Save();
        }

        public void Update(BulgarianWord word)
        {
            this.words.Update(word);
            this.words.Save();
        }

        public void Delete(BulgarianWord word)
        {
            if (this.words.GetById(word.Id) == null)
            {
                return;
            }

            this.words.Delete(word);
            this.words.Save();
        }
    }
}
