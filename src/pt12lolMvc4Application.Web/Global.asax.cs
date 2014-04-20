using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;
using pt12lolMvc4Application.Db.Wrapper;
using pt12lolMvc4Application.Services;
using WebMatrix.WebData;

namespace pt12lolMvc4Application.Web
{
    public class MvcApplication : HttpApplication
    {
        readonly ILog _logger;
        readonly ILogHelper _logHelper;

        SimpleMembershipInitializer _initializer;
        object _initializerLock;
        bool _isInitialized;

        public MvcApplication()
        {
            _logger = LogManager.GetLogger(GetType());
            _logHelper = new LogHelper();

            _initializerLock = new object();
        }

        protected void Application_Start()
        {
            try
            {
                XmlConfigurator.Configure();
                _logger.Info("Application is starting...");

                AreaRegistration.RegisterAllAreas();
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterAuth();

                _logger.Debug("Lazy initialization has started.");
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
                _logger.Debug("Lazy initialization succeded.");

                pt12lolConfigurator.ConfigureAutoMapper();
                pt12lolConfigurator.InitializeDbConnection();

                _logger.Info("Application has been configured.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            _logger.Info("Application has started successfully.");
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

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                WebSecurity.InitializeDatabaseConnection("AuthenticationConnection", "UserProfiles", "UserId", "UserName", autoCreateTables: true);
            }
        }
    }
}