using News.Data;
using News.Data.Contracts;

namespace News.Web
{
    public abstract class BasePage : System.Web.UI.Page
    {
        public IAppData Data { get; set; }

        protected BasePage()
        {
            this.Data = new AppData();
        }
    }
}