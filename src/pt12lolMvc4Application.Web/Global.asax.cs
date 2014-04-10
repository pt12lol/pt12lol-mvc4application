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
        readonly ILog logger;
        readonly ILogHelper logHelper;

        public MvcApplication()
        {
            logger = LogManager.GetLogger(this.GetType());
            logHelper = new LogHelper();
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
            logger.Info("Application has started");
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode >= 200 && Response.StatusCode < 300)
            {
                logger.Info(logHelper.FormatLog(Response));
            }
            else
            {
                logger.Warn(logHelper.FormatLog(Response));
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            logger.Info(logHelper.FormatLog(Request));
        }
    }
}