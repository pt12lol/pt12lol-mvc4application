using System.Web.Mvc;
using log4net;

namespace pt12lolMvc4Application.Web.Filters
{
    class LoggingExceptionFilter : IExceptionFilter
    {
        readonly IExceptionFilter _filter;
        readonly ILog _logger;

        public LoggingExceptionFilter(IExceptionFilter filter, ILog logger)
        {
            _filter = filter;
            _logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            _logger.Error(filterContext.Exception);
            _filter.OnException(filterContext);
        }
    }
}