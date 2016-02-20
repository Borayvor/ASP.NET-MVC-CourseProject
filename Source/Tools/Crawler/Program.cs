namespace Crawler
{
    ////using System;
    ////using AngleSharp;
    ////using InteractiveLearningSystem.Data;
    ////using InteractiveLearningSystem.Data.Common;
    ////using InteractiveLearningSystem.Data.Models.CrosswordModels.Bulgarian;
    ////using InteractiveLearningSystem.Services.Data;

    public static class Program
    {
        public static void Main()
        {
            ////var db = new InteractiveLearningSystemDbContext();
            ////var repo = new DbRepository<BulgarianWord>(db);
            ////var wordsService = new BulgarianWordService(repo);

            ////var configuration = Configuration.Default.WithDefaultLoader();
            ////var browsingContext = BrowsingContext.New(configuration);

            ////for (int i = 1; i <= 10000; i++)
            ////{
            ////    var url = $"http://rechnik.chitanka.info/type/{i}";
            ////    var document = browsingContext.OpenAsync(url).Result;
            ////    var name = document.QuerySelector("#content .words").TextContent.Trim().Split(new char[] { '\n', '\t' });

            ////    for (int index = 0; index < name.Length; index++)
            ////    {
            ////        if (!string.IsNullOrWhiteSpace(name[index]))
            ////        {
            ////            //var categoryName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();
            ////            //var category = WordsService.EnsureWord(jokeContent);
            ////            var wordName = new BulgarianWord { Name = name[index] };
            ////            db.Words.Add(wordName);

            ////        }
            ////    }


            ////    db.SaveChanges();
            ////    Console.WriteLine(i);
            ////}
        }
    }
}
