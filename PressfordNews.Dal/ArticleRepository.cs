using PressfordNews.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressfordNews.Model;
using Dapper;

namespace PressfordNews.Dal
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DatabaseService _database;

        public ArticleRepository()
        {
            _database = new DatabaseService();
        }

        public void Create(Article article)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "insert into Article (Title, Body, PublisherId, PublishDate) values (@title, @body, @publisherId, @publishDate)";
                conn.Execute(sql,
                    new
                    {
                        title = article.Title,
                        body = article.Body,
                        publisherId = article.PublisherId,
                        publishDate = article.PublishDate
                    });
            }
        }

        public void Delete(int articleId)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "update Article set IsDeleted = 1 where ArticleId = @id";
                conn.Execute(sql, new { id = articleId });
            }
        }

        public Article Get(int id)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from Article where IsDeleted = 0 and ArticleId = @id";
                return conn.Query<Article>(sql, new { id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Article> GetAllArticles()
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "select * from Article where IsDeleted = 0 order by PublishDate desc";
                return conn.Query<Article>(sql);
            }
        }

        public void Update(Article article)
        {
            using (var conn = _database.NewConnection)
            {
                string sql = "update Article set Title = @title, Body = @body, PublisherId = @publisherId, PublishDate = @publishDate where ArticleId = @id";
                conn.Execute(sql,
                    new
                    {
                        title = article.Title,
                        body = article.Body,
                        publisherId = article.PublisherId,
                        publishDate = article.PublishDate,
                        id = article.ArticleId
                    });
            }
        }
    }
}
