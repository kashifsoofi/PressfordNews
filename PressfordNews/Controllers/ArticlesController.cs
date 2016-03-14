using AutoMapper;
using PressfordNews.Model;
using PressfordNews.Models;
using PressfordNews.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PressfordNews.Controllers
{
    [Authorize]
    [RoutePrefix("articles")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Article
        [Route("~/")]
        public ActionResult Index()
        {
            ViewBag.MostRecent = true;
            var model = _articleService.GetArticles();
            return View(model);
        }

        [Route("toprated")]
        public ActionResult TopRated()
        {
            ViewBag.MostRecent = false;
            var model = _articleService.GetTopRated();
            return View("Index", model);
        }

        [Route("comment")]
        [HttpPost]
        public ActionResult Comment(CommentViewModel model)
        {
            var user = Session["CurrentUser"] as AppUser;
            var article = new Article { ArticleId = model.ArticleId };
            _articleService.AddComment(article, user, model.Comment);
            return RedirectToAction("Index");
        }

        [Route("publish")]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ArticleCreateViewModel();
            return View(model);
        }

        [Route("publish")]
        [HttpPost]
        public ActionResult Create(ArticleCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = Session["CurrentUser"] as AppUser;
            var articleToCreate = Mapper.Map<Article>(model);
            _articleService.Create(user, articleToCreate);
            return RedirectToAction("Index");
        }

        [Route("update")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Article article = _articleService.Get(id);
            var model = Mapper.Map<ArticleEditViewModel>(article);
            return View(model);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Edit(ArticleEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = Session["CurrentUser"] as AppUser;
            var articleToEdit = Mapper.Map<Article>(model);
            _articleService.Update(user, articleToEdit);
            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}