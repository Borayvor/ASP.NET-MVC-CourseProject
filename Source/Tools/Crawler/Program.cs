namespace Crawler
{
    using System;
    using System.Text.RegularExpressions;
    using AngleSharp;
    using InteractiveLearningSystem.Data;
    using InteractiveLearningSystem.Data.Common;
    using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;
    using InteractiveLearningSystem.Services.Data;

    public static class Program
    {
        public static void Main()
        {
            var db = new InteractiveLearningSystemDbContext();
            var repo = new DbRepository<BulgarianWord>(db);
            var wordsService = new EnsureWordsService(repo);

            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);

            string pattern = @"\b[а-яА-Я]+\b";
            Regex regEx = new Regex(pattern);

            for (int i = 1; i <= 300; i++)
            {
                var url = $"http://rechnik.chitanka.info/type/{i}";
                var document = browsingContext.OpenAsync(url).Result;

                string[] name = new string[0];

                try
                {
                    name = document.QuerySelector("#content .words").TextContent.Trim().Split(new char[] { '\n', '\t' });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                for (int index = 0; index < name.Length; index++)
                {
                    if (!string.IsNullOrWhiteSpace(name[index]) &&
                        regEx.IsMatch(name[index]))
                    {
                        var wordName = new BulgarianWord { Name = name[index] };
                        db.Words.Add(wordName);
                    }
                }


                db.SaveChanges();
                Console.WriteLine(i);
            }
        }
    }
}
