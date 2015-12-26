using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using News.Data.Migrations;
using News.Models;

namespace News.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Like> Likes { get; set; }
    }
}
