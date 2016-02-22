namespace InteractiveLearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using InteractiveLearningSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.WordModels;
    using Models.WordModels.Bulgarian;

    public sealed class Configuration : DbMigrationsConfiguration<InteractiveLearningSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InteractiveLearningSystemDbContext context)
        {
            this.SeedUsers(context);

            this.SeedLanguagesWithWordsWithQuestions(context);
        }

        private void SeedUsers(InteractiveLearningSystemDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            // Create admin role
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
            roleManager.Create(role);

            // Create admin user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
            userManager.Create(user, AdministratorPassword);

            // Assign user to admin role
            userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);

            context.SaveChanges();
        }

        private void SeedLanguagesWithWordsWithQuestions(InteractiveLearningSystemDbContext context)
        {
            if (context.Languages.Any())
            {
                return;
            }

            var bulgarianLanguage = new Language()
            {
                Name = "Bulgarian",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            var word = new BulgarianWord
            {
                Name = "бягане",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            var question = new BulgarianQuestion
            {
                Content = "Вид движение на човека ?",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            word.Questions.Add(question);
            bulgarianLanguage.BulgarianWords.Add(word);

            word = new BulgarianWord
            {
                Name = "слух",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            question = new BulgarianQuestion
            {
                Content = "Едно от петте сетива ?",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            word.Questions.Add(question);
            bulgarianLanguage.BulgarianWords.Add(word);

            word = new BulgarianWord
            {
                Name = "лъв",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            question = new BulgarianQuestion
            {
                Content = "Царят на животните ?",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            word.Questions.Add(question);
            bulgarianLanguage.BulgarianWords.Add(word);

            context.Languages.Add(new Language() { Name = "English", CreatedOn = DateTime.UtcNow, IsDeleted = false });

            context.SaveChanges();
        }
    }
}
