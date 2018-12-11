using LovePlatform.Domain;
using LovePlatform.Service.AutoMapperConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using LovePlatform.WebAPI.Middleware;
using LovePlatform.Service;
using LovePlatform.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace LovePlatform.WebAPI
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            DtoMapping.WebApiConfigure();

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));

            // Add framework services.
            services.AddDbContext<LovePlatformContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateModelAttribute());
                options.Filters.Add(new CustomExceptionFilterAttribute());
            }).AddJsonOptions(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Add application services.
            services.AddScoped<PatientService>();
            services.AddScoped<WeightService>();
            services.AddScoped<UserService>();
            services.AddScoped<TreatService>();
            services.AddScoped<TreatImageService>();
            services.AddScoped<DiagnoseService>();
            services.AddScoped<OssService>();
            services.AddScoped<UserService>();
            services.AddScoped<BloodPressureService>();

            services.AddScoped<PatientRepository>();
            services.AddScoped<WeightRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<TreatRepository>();
            services.AddScoped<TreatImageRepository>();
            services.AddScoped<DiagnoseRepository>();
            services.AddScoped<OssRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<BloodPressureRepository>();

            services.AddScoped<IUnitWork, UnitWork>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WebAPI", Version = "v1" });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var webapiXmlPath = Path.Combine(basePath, "LovePlatform.WebAPI.xml");
                c.IncludeXmlComments(webapiXmlPath);
                var domainXmlPath = Path.Combine(basePath, "LovePlatform.DTO.xml");
                c.IncludeXmlComments(domainXmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRequestLogger();

            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1");
            });
        }
    }
}
