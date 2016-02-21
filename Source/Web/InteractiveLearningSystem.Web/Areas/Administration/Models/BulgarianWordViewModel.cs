namespace InteractiveLearningSystem.Web.Areas.Administration.Models
{
    using Data.Models.CrosswordModels.Bulgarian;
    using Infrastructure.Mapping;
    using Services.Web;

    public class BulgarianWordViewModel : IMapFrom<BulgarianWord>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();

                return string.Format("/Administration/Words/{0}", identifier.EncodeId(this.Id));
            }
        }
    }
}