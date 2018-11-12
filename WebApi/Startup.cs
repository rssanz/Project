using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceRate.Interfaces;
using ServiceRate.Implementations;
using ServiceTransaction.Interfaces;
using ServiceTransaction.Implementations;
using ServiceUtils.Interfaces;
using ServiceUtils.Implementations;
using Data.DataAccess;
using ServiceRate;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRateItemDao, RateItemDao>();
            services.AddScoped<ITransactionItemDao, TransactionItemDao>();

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            app.UseMvc();
        }
    }
}