
using News.Models;

namespace News.Data.Contracts
{
    public interface IAppData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Like> Likes { get; }

        void SaveChanges();
    }
}
