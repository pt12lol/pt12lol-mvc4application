using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using pt12lolMvc4Application.Services;
using pt12lolMvc4Application.Services.Interfaces;

namespace pt12lolMvc4Application.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly ILog log;
        readonly ILogHelper logHelper;

        public HomeController()
        {
            log = LogManager.GetLogger(this.GetType());
            logHelper = new LogHelper();
        }

        public ActionResult Index()
        {
            log.Info(logHelper.FormatLog(Request));
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            log.Info(logHelper.FormatLog(Request));
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            log.Info(logHelper.FormatLog(Request));
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
