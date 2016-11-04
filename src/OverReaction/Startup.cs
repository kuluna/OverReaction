using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OverReaction.Models;
using System.Reflection;

namespace OverReaction
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        /// General Configuration
        public IConfigurationRoot Configuration { get; }

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddOptions();
            services.AddMvc();
            
            services.AddSwaggerGen(setting =>
            {
                var location = Assembly.GetEntryAssembly().Location;
                var xmlPath = location.Replace("dll", "xml");
                setting.IncludeXmlComments(xmlPath);
            });

            services.Configure<AppSetting>(Configuration.GetSection(nameof(AppSetting)));
        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseMvc();
        }
    }
}
