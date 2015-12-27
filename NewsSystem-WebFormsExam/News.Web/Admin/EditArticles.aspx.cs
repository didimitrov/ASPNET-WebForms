using System;
using System.Collections.Generic;
using System.Linq;
using News.Models;

namespace News.Web.Admin
{
    public partial class EditArticles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression

        public IQueryable<Article> ArticlesEditor_GetData()
        {
            return this.Data.Articles.All().OrderBy(a => a.Id);
        }

        public void ArticlesEditor_DeleteItem(int id)
        {
            var article = this.Data.Articles.All().FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
               // ErrorSuccessNotifier.AddErrorMessage("Article cannot be matched");
                return;
            }

            this.Data.Articles.Delete(article);
            Data.SaveChanges();


            //ErrorSuccessNotifier.AddSuccessMessage("Article successfully deleted.");
        }

        public void ArticlesEditor_UpdateItem(int id)
        {
            var item = this.Data.Articles.All().FirstOrDefault(a => a.Id == id);
            if (item==null)
            {
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                if (string.IsNullOrEmpty(item.Title))
                {
                   // ErrorSuccessNotifier.AddErrorMessage("Article's title cannot be empty");
                    return;
                }

                if (string.IsNullOrEmpty(item.Content))
                {
                    //ErrorSuccessNotifier.AddErrorMessage("Article's content cannot be empty");
                    return;
                }

                if (item.Title.Trim().Length < 2)
                {
                    //ErrorSuccessNotifier.AddErrorMessage("Article's title cannot be less than 2 symbols");
                    return;
                }

                if (item.Content.Trim().Length < 5)
                {
                    //ErrorSuccessNotifier.AddErrorMessage("Article's title cannot be less than 5 symbols");
                    return;
                }

                var currentArticle = this.Data.Articles.All().FirstOrDefault(a => a.Id == id);

                currentArticle.Title = item.Title;
                currentArticle.Content = item.Content;
                currentArticle.Category = this.Data.Categories.All().FirstOrDefault(c => c.Name == item.Category.Name);

                this.Data.Articles.Update(currentArticle);
                Data.SaveChanges();

                //ErrorSuccessNotifier.AddSuccessMessage("Article successfully updated.");

            }
            else
            {
              //  ErrorSuccessNotifier.AddWarningMessage("Article cannot be updated due to invalid article data");
            }
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.Data.Categories.All().OrderBy(b => b.Name);
        }
    }
}