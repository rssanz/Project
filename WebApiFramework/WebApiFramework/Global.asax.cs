using Autofac;
using Autofac.Integration.WebApi;
using Data_EF.Contexts;
using Data_EF.Repositories;
using Data_EF.UnitOfWork;
using DataEntities.Domain;
using ServiceRate.Implementations;
using ServiceRate.Interfaces;
using ServiceTransaction.Implementations;
using ServiceTransaction.Interfaces;
using ServiceUtils.Implementations;
using ServiceUtilsInterface.Interfaces;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Routing;
using WebApiFramework.Modules;

namespace WebApiFramework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Autofac Configuration
            RegisterAutofac();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

        private static void RegisterAutofac()
        {
            var config = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();

            #region configuracion
            //DbContext
            var conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
            builder.RegisterType<MyDbContext>().As<IDbContext>()
                .WithParameter("connection", conn);

            //Registrar la inyección de dependecias
            builder.RegisterType<RateService>().As<IRateService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<RequestService>().As<IRequestService>();

            //Unit of Work
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //Repositories
            builder.RegisterType<GenericRepository<Rate>>().As<IGenericRepository<Rate>>();
            builder.RegisterType<GenericRepository<Transaction>>().As<IGenericRepository<Transaction>>();

            //AutoMapper
            builder.RegisterModule(new AutoMapperModule());

            //Log4net
            builder.RegisterModule(new LoggingModule());
            #endregion

            //Registrar los Controladores de la WebApi
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
