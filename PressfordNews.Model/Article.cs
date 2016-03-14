using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Model
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PublisherId { get; set; }
        public DateTime PublishDate { get; set; }

        public AppUser Publisher { get; set; }
        public List<ArticleLike> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
