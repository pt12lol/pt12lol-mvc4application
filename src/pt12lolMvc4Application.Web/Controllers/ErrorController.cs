using System.Web.Mvc;

namespace pt12lolMvc4Application.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}
