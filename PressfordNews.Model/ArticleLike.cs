using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Model
{
    public class ArticleLike
    {
        public int LikeId { get; set; }
        public int ArticleId { get; set; }
        public int LikedById { get; set; }
        public DateTime LikeDate { get; set; }
    }
}
