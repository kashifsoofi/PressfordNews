using AutoMapper;
using PressfordNews.Model;
using PressfordNews.Models;
using PressfordNews.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PressfordNews.Controllers
{
    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : Controller
    {
        private readonly IAppUserService _userService;

        public AccountController(IAppUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("login")]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // authenticate if found in db
            var user = _userService.GetByUsername(model.Username);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                Session["CurrentUser"] = user;

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Articles");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("logoff")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Articles", new { area = "" });
        }

        [AllowAnonymous]
        [Route("register")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public ActionResult Create(UserCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userToCreate = Mapper.Map<AppUser>(model);
            _userService.Create(userToCreate);
            return RedirectToAction("Login");
        }
    }
}