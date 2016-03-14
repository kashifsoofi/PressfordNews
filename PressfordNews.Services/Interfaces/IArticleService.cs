using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Services.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> GetTopRated();
        Article Get(int id);
        void Create(AppUser user, Article article);
        void Update(AppUser user, Article article);
        void Delete(int articleId);

        void LikeArticle(Article article, AppUser user);
        void AddComment(Article article, AppUser user, string comment);
    }
}
