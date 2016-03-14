using PressfordNews.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressfordNews.Dal.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetCommentsForArticle(int articleId);
        IEnumerable<Comment> GetCommentsByUser(int userId);
        void Create(Comment comment);
        void Delete(int commentId);
    }
}
