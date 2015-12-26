using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class Category
    {
        public Category()
        {
            this.Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
