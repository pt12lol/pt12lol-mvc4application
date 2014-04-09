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
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        readonly ILog log;
        readonly ILogHelper logHelper;

        public MvcApplication()
        {
            log = LogManager.GetLogger(this.GetType());
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
            log.Info("Application has started");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            log.Error(Server.GetLastError());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            log.Info(logHelper.FormatLog(Request));
        }
    }
}