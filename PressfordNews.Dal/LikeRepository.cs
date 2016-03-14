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
    public class LikeRepository : ILikeRepository
    {
        private readonly DatabaseService _database;

        public LikeRepository()
        {
            _database = new DatabaseService();
        }

        public void Create(ArticleLike like)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "insert into ArticleLike (ArticleId, LikedById, LikeDate) values (@articleId, @likedBy, @likeDate)";
                conn.Execute(sql,
                    new
                    {
                        articleId = like.ArticleId,
                        likedBy = like.LikedById,
                        likeDate = like.LikeDate
                    });
            }
        }

        public void Delete(int likeId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "delete from ArticleLike where LikeId = @likeId";
                conn.Execute(sql, new { likeId = likeId });
            }
        }

        public IEnumerable<ArticleLike> GetAllLikes()
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from ArticleLike";
                return conn.Query<ArticleLike>(sql);
            }
        }

        public IEnumerable<ArticleLike> GetLikesByUser(int userId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from ArticleLike where LikedById = @userId";
                return conn.Query<ArticleLike>(sql, new { userId = userId });
            }
        }

        public IEnumerable<ArticleLike> GetLikesForArticle(int articleId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from ArticleLike where ArticleId = @articleId";
                return conn.Query<ArticleLike>(sql, new { articleId = articleId });
            }
        }
    }
}
