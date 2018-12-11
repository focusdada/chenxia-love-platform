using LovePlatform.Service.AutoMapperConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace LovePlatform.H5
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DtoMapping.H5Configure();

            // Add framework services.
            services.AddMvc().AddJsonOptions(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));

            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Sign}/{action=Check}/{code?}");
            });

            app.UseFileServer(enableDirectoryBrowsing: true);

            //启用目录浏览
            app.UseFileServer(new FileServerOptions()                                       
            {                                                                               
                FileProvider = new PhysicalFileProvider(                                    
                Path.Combine(Directory.GetCurrentDirectory(), @"")),       
                RequestPath = new PathString(""),                               
                EnableDirectoryBrowsing = true                                              
            });
        }
    }
}
