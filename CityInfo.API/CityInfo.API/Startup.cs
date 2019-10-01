using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using CityInfo.API.Services;
using Microsoft.Extensions.Configuration;
using CityInfo.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            //Configuration = builder.Build();
               Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
            //.AddJsonOptions(o =>
            // {
            //     if (o.SerializerSettings.ContractResolver != null)
            //     {
            //         var castedResolver = o.SerializerSettings.ContractResolver
            //         as DefaultContractResolver;
            //         castedResolver.NamingStrategy = null;
            //     }
            // });
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<CityInfoContext>(option
                => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICityInfoRepository,CItyInfoRepository>();


#if DEBUG
            services.AddTransient<IMailService,LocalMailService>();
#else
            services.AddTransient<IMailService,CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory,
            CityInfoContext context)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            // loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());

            loggerFactory.AddNLog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseMvc();
            app.UseStatusCodePages();
            context.EnsureSeedDataForContext();
            // AutoMapper.Mapper.ReferenceEquals(Entity.City,Models.CityWithoutPointsOfInterestDto);
            AutoMapper.Mapper.Initialize(ctg =>
            {
                ctg.CreateMap<Entity.City, Models.CityWithoutPointsOfInterestDto>();
                ctg.CreateMap<Entity.City, Models.CityDto>();
                ctg.CreateMap<Entity.PointsOfInterest, Models.PointOfInterestDto>();
            });
            
            //app.Run((context) =>
            //{
            //    throw new Exception("Example exception");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
