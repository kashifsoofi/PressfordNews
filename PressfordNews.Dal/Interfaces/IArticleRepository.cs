using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Dal.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAllArticles();
        Article Get(int id);
        void Create(Article article);
        void Update(Article article);
        void Delete(int articleId);
    }
}
