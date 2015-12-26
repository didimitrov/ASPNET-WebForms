namespace News.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<News.Data.ApplicationDbContext>
    {
        private readonly SeedData seeder;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            this.seeder = new SeedData();
        }

        protected override void Seed(News.Data.ApplicationDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            foreach (var category in this.seeder.Categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            if (context.Articles.Any())
            {
                return;
            }

            foreach (var article in this.seeder.Articles)
            {
                context.Articles.Add(article);
            }
            context.SaveChanges();
        }
    }
}
