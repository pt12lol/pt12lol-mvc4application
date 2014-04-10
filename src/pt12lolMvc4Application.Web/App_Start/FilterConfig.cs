using System.Web;
using System.Web.Mvc;
using log4net;
using pt12lolMvc4Application.Services;
using pt12lolMvc4Application.Web.Filters;

namespace pt12lolMvc4Application.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoggingExceptionFilter(new HandleErrorAttribute(), LogManager.GetLogger("ExceptionLogger")));
        }
    }
}