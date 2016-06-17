using Funq;
using ServiceStack;
using SelfHost1.ServiceInterface;
using SelfHost1.ConfigurationHelper;
using ServiceStack.Host.HttpListener;
using System.Net;
using ServiceStack.Auth;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using System;
using ServiceStack.OrmLite;
using System.Configuration;
using ServiceStack.OrmLite.SqlServer;
using SelfHost1.DataAccess.Repository.Implementation;
using SelfHost1.DataAccess.Repository;
using ServiceStack.Data;

namespace SelfHost1
{
    public class AppHost : AppSelfHostBase
    {
        public static ILog Logger;

        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("SelfHost1", typeof(ShipperService).Assembly)
        {
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);

            Logger = LogManager.GetLogger(typeof(AppHost));
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            this.GlobalRequestFilters.Add((req, res, requestDto) =>
            {
                var apiKey = req.Headers["X-ApiKey"];

                if (apiKey == null || !Clients.VerifyKey(apiKey))
                {
                    Logger.Info(string.Format("{0} - {1} : Auth key wrong!", DateTime.Now, apiKey));
                    res.ReturnAuthRequired("Auth key wrong!");
                }
            });

            var connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

            var ormLiteConnectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerOrmLiteDialectProvider.Instance);

            container.Register<IDbConnectionFactory>(ormLiteConnectionFactory);

            container.RegisterAs<ShipperRepository, IShipperRepository>();

            this.Plugins.Add(new PostmanFeature());

            this.Plugins.Add(new CorsFeature());
        }
    }
}
