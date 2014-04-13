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
using pt12lolMvc4Application.Services;
using pt12lolMvc4Application.Services.Interfaces;
using pt12lolMvc4Application.Web.Models;
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
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);

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

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}