using PressfordNews.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressfordNews.Model;
using System.Configuration;
using Dapper;

namespace PressfordNews.Dal
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DatabaseService _database;

        public CommentRepository()
        {
            _database = new DatabaseService();
        }

        public void Create(Comment comment)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "insert into Comment (CommentText, ArticleId, CommentedById, CommentDate) values (@commentText, @articleId, @commentedBy, @commentDate)";
                conn.Execute(sql,
                    new
                    {
                        commentText = comment.CommentText,
                        articleId = comment.ArticleId,
                        commentedBy = comment.CommentedById,
                        commentDate = comment.CommentDate
                    });
            }
        }

        public void Delete(int commentId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "delete from Comment where CommentId = @commentId";
                conn.Execute(sql, new { commentId = commentId });
            }
        }

        public IEnumerable<Comment> GetAllComments()
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from Comment";
                return conn.Query<Comment>(sql);
            }
        }

        public IEnumerable<Comment> GetCommentsByUser(int userId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from Comment where CommentedById = @userId";
                return conn.Query<Comment>(sql, new { userId = userId });
            }
        }

        public IEnumerable<Comment> GetCommentsForArticle(int articleId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from Comment where ArticleId = @articleId Order by CommentDate desc";
                return conn.Query<Comment>(sql, new { articleId = articleId });
            }
        }
    }
}
