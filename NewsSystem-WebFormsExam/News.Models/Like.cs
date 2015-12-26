using System.ComponentModel;

namespace News.Models
{
    public class Like
    {
        public int Id { get; set; }

        [DefaultValue(0)]
        public int Value { get; set; }
    }
}
