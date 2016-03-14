using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PressfordNews.Services.Interfaces;
using PressfordNews.Dal.Interfaces;
using AutoMapper;
using PressfordNews.Model;

namespace PressfordNews.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;

        public ArticleService(IAppUserRepository userRepository, IArticleRepository articleRepository, ICommentRepository commentRepository, ILikeRepository likeRepository)
        {
            _userRepository = userRepository;
            _articleRepository = articleRepository;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
        }

        public void Create(AppUser user, Article article)
        {
            article.PublisherId = user.UserId;
            article.PublishDate = DateTime.Now;

            _articleRepository.Create(article);
        }

        public void Delete(int articleId)
        {
            _articleRepository.Delete(articleId);
        }

        public Article Get(int id)
        {
            return _articleRepository.Get(id);
        }

        public IEnumerable<Article> GetArticles()
        {
            var users = _userRepository.GetAllUsers().ToList();

            var articles = _articleRepository.GetAllArticles().ToList();

            // This is very bad, use lazy loading
            foreach (var article in articles)
            {
                article.Publisher = users.FirstOrDefault(x => x.UserId == article.PublisherId);
                article.Comments = _commentRepository.GetCommentsForArticle(article.ArticleId).ToList();
                article.Likes = _likeRepository.GetLikesForArticle(article.ArticleId).ToList();
            }
            return articles;
        }

        public IEnumerable<Article> GetTopRated()
        {
            var users = _userRepository.GetAllUsers().ToList();
            var articles = _articleRepository.GetAllArticles().ToList();

            // This is very bad, use lazy loading
            foreach (var article in articles)
            {
                article.Publisher = users.FirstOrDefault(x => x.UserId == article.PublisherId);
                article.Comments = _commentRepository.GetCommentsForArticle(article.ArticleId).ToList();
                article.Likes = _likeRepository.GetLikesForArticle(article.ArticleId).ToList();
            }
            return articles.OrderByDescending(a => a.Likes.Count);
        }

        public void LikeArticle(Article article, AppUser user)
        {
            ArticleLike like = new ArticleLike
            {
                ArticleId = article.ArticleId,
                LikedById = user.UserId,
                LikeDate = DateTime.Now
            };
            _likeRepository.Create(like);
        }

        public void Update(AppUser user, Article article)
        {
            article.PublisherId = user.UserId;
            article.PublishDate = DateTime.Now;

            _articleRepository.Update(article);
        }

        public void AddComment(Article article, AppUser user, string commentText)
        {
            Comment comment = new Comment
            {
                CommentText = commentText,
                CommentDate = DateTime.Now,
                ArticleId = article.ArticleId,
                CommentedById = user.UserId
            };
            _commentRepository.Create(comment);
        }
    }
}
