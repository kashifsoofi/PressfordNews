using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int ArticleId { get; set; }
        public int CommentedById { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
