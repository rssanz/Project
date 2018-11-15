using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ServiceRate.Interfaces;
using ServiceRate.Implementations;
using ServiceTransaction.Interfaces;
using ServiceTransaction.Implementations;
using ServiceUtils.Interfaces;
using ServiceUtils.Implementations;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Data_EF.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Data_EF.UnitOfWork;
using System.Collections.Generic;
using System;
using DataEntities.Domain;
using Data_EF.Repositories;
using AutoMapper;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .AddJsonFile($"appsettings.{env.EnvironmentName}json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //DB
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataContextDB")));

            //Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repositories
            services.AddScoped<IGenericRepository<Rate>, GenericRepository<Rate>>();
            services.AddScoped<IGenericRepository<Transaction>, GenericRepository<Transaction>>();

            //Other Services
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<ITransactionService, TransactionService>();

            //Automapper
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            app.UseMvc();
        }
    }
}