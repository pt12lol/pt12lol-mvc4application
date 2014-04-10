using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Appender;
using log4net.Config;
using pt12lolMvc4Application.Services;
using pt12lolMvc4Application.Services.Interfaces;

namespace pt12lolMvc4Application.Web
{
    public class MvcApplication : HttpApplication
    {
        readonly ILog _logger;
        readonly ILogHelper _logHelper;

        public MvcApplication()
        {
            _logger = LogManager.GetLogger(this.GetType());
            _logHelper = new LogHelper();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            XmlConfigurator.Configure();
            _logger.Info("Application has started");
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode >= 200 && Response.StatusCode < 300)
            {
                _logger.Info(_logHelper.FormatLog(Response));
            }
            else
            {
                _logger.Warn(_logHelper.FormatLog(Response));
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            _logger.Info(_logHelper.FormatLog(Request));
        }
    }
}