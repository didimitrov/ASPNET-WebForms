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
            var articleTitle = Server.HtmlEncode(this.TextBoxArticleTitle.Text.Trim());
            if (string.IsNullOrEmpty(articleTitle))
            {
              //  ErrorSuccessNotifier.AddErrorMessage("Article's title cannot be empty");
                return;
            }

            var articleContent = Server.HtmlEncode(this.TextBoxArticleContent.Text.Trim());
            if (string.IsNullOrEmpty(articleContent))
            {
               // ErrorSuccessNotifier.AddErrorMessage("Article's content cannot be empty");
                return;
            }

            var articleCategoryId = Convert.ToInt32(this.DropDownListArticleCategory.SelectedValue);
            if (articleCategoryId==0)
            {
              //  ErrorSuccessNotifier.AddErrorMessage("Article's category doesn't match existing ones.");
                return;
            }

            var like = new Like() {Value = 0};

            var article = new Article()
            {
                Title = articleTitle,
                Content = articleContent,
                CategoryId = articleCategoryId,
                Category = this.Data.Categories.All().FirstOrDefault(c => c.Id == articleCategoryId),
                AuthorId = this.Data.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name).Id,
                Author = this.Data.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name),
                DateCreated = DateTime.Now
            };

            this.Data.Articles.Add(article);
            this.Data.SaveChanges();

            article.Likes = like;
            this.Data.Articles.Update(article);
            this.Data.SaveChanges();

          //  ErrorSuccessNotifier.AddSuccessMessage("Article created successfully");
            Response.Redirect("~/Admin/EditArticles");
        }
    }
}