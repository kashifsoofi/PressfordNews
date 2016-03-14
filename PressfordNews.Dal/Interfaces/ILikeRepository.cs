using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Dal.Interfaces
{
    public interface ILikeRepository
    {
        IEnumerable<ArticleLike> GetAllLikes();
        IEnumerable<ArticleLike> GetLikesForArticle(int articleId);
        IEnumerable<ArticleLike> GetLikesByUser(int userId);
        void Create(ArticleLike like);
        void Delete(int likeId);
    }
}
