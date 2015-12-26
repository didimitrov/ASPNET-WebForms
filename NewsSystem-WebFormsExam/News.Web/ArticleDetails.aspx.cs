using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin;
using News.Models;

namespace News.Web
{
    public partial class ArticleDetails : BasePage
    {
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Article FormViewArticleDetails_GetItem([QueryString("id")]int? articleId)
        {
            if (articleId== null)
            {
               // ErrorSuccessNotifier.AddErrorMessage("Following article does not exist");
                Response.Redirect("~/");
            }

            return this.Data.Articles.All().FirstOrDefault(x => x.Id == articleId);
        }

        private Article GetCurrentArticle()
        {
            var articleId = Convert.ToInt32(Request.QueryString["id"]);

            if (articleId == 0)
            {
                //ErrorSuccessNotifier.AddErrorMessage("Following article does not exist");
                Response.Redirect("~/");
            }

            return this.Data.Articles.All().FirstOrDefault(a => a.Id == articleId);
        }

        protected int GetLikesValue()
        {
            var article = this.GetCurrentArticle();

            return article.Likes.Value;
        }

        protected void LikeBtn_Click(object sender, EventArgs e)
        {
            var article = this.GetCurrentArticle();

            article.Likes.Value++;

            this.Data.Articles.Update(article);
            this.Data.SaveChanges();
        }

        protected void DislikeBtn_Click(object sender, EventArgs e)
        {
            var article = this.GetCurrentArticle();

            article.Likes.Value--;

            if (article.Likes.Value < 0)
            {
                article.Likes.Value = 0;
            }

            this.Data.Articles.Update(article);
            this.Data.SaveChanges();
        }
    }
}