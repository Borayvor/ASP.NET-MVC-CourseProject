namespace InteractiveLearningSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using InteractiveLearningSystem.Data.Common;
    using InteractiveLearningSystem.Data.Models.WordModels.Bulgarian;
    using Web;

    public class BulgarianQuestionsService : IBulgarianQuestionsService
    {
        private readonly IDbRepository<BulgarianQuestion> questions;
        private readonly IIdentifierProvider identifierProvider;

        public BulgarianQuestionsService(IDbRepository<BulgarianQuestion> questions, IIdentifierProvider identifierProvider)
        {
            this.questions = questions;
            this.identifierProvider = identifierProvider;
        }

        public BulgarianQuestion GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var question = this.questions.GetById(intId);

            return question;
        }

        public IQueryable<BulgarianQuestion> GetAll()
        {
            return this.questions.All().OrderBy(x => x.CreatedOn);
        }

        public void Add(BulgarianQuestion question)
        {
            this.questions.Add(question);
            this.questions.Save();
        }

        public void Update(BulgarianQuestion question)
        {
            this.questions.Update(question);
            this.questions.Save();
        }

        public void Delete(BulgarianQuestion question)
        {
            this.questions.Delete(question);
            this.questions.Save();
        }
    }
}
