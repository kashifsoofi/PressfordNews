using PressfordNews.Model;
using PressfordNews.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PressfordNews.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/articles")]
    public class ArticlesController : ApiController
    {
        private readonly IArticleService _articleService;
        private readonly IAppUserService _userService;

        public ArticlesController(IArticleService articleService, IAppUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            return _articleService.GetArticles();
        }

        [Route("like/{articleId}")]
        [HttpPost]
        public void Like(int articleId)
        {
            var article = new Article { ArticleId = articleId };
            var user = _userService.GetByUsername(RequestContext.Principal.Identity.Name);
            _articleService.LikeArticle(article, user);
        }
    }
}
