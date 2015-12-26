using System;
using System.Collections;
using System.Linq;
using News.Models;

namespace News.Web.Admin
{
    public partial class CreateArticle : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.Data.Categories.All().OrderBy(c => c.Name);

        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}