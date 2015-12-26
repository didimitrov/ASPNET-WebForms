using System;
using System.Collections.Generic;
using System.Linq;
using News.Models;


namespace News.Web
{
    public partial class Home : BasePage
    {
        private const int DefaultPopularArticlesCount = 3;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Article> ListViewPopularArticles_GetData()
        {
            return this.Data.Articles.All().OrderByDescending(l => l.Likes.Value).Take(DefaultPopularArticlesCount);
        }

        public IEnumerable<Category> ListViewCategories_GetData()
        {
            return this.Data.Categories.All().OrderBy(n => n.Name);
        }
    }
}