﻿using System.Web.Mvc;
using log4net;

namespace pt12lolMvc4Application.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ILog _logger;

        public HomeController()
        {
            _logger = LogManager.GetLogger(this.GetType());
        }

        public HomeController(ILog logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
