using System.Web.Mvc;

namespace pt12lolMvc4Application.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View();
        }

    }
}
