using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PressfordNews.Models
{
    public class ArticleCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }

    public class ArticleEditViewModel
    {
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }

    public class CommentViewModel
    {
        public int ArticleId { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}