using LovePlatform.Domain;
using LovePlatform.Repository;
using LovePlatform.Service;
using LovePlatform.Service.AutoMapperConfig;
using LovePlatform.WebAdmin.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace LovePlatform.WebAdmin
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
            DtoMapping.WebAdminConfigure();

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));

            services.AddDbContext<LovePlatformContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("LovePlatform.WebAdmin")));

            services.AddMvc(options => options.Filters.Add(new CustomExceptionFilterAttribute()))
                .AddJsonOptions(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;

            services.AddSession(options =>
            {
                options.CookieName = "LovePlatform";
            });

            // Add application services.
            services.AddScoped<LovePlatformAdminApi>();
            services.AddScoped<AdministratorService>();
            services.AddScoped<PatientService>();
            services.AddScoped<WeightService>();
            services.AddScoped<UserService>();
            services.AddScoped<UserService>();
            services.AddScoped<DiagnoseService>();
            services.AddScoped<TreatService>();
            services.AddScoped<TreatImageService>();
            services.AddScoped<BloodPressureService>();
            //Repository
            services.AddScoped<AdministratorRepository>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<WeightRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<DiagnoseRepository>();
            services.AddScoped<TreatRepository>();
            services.AddScoped<TreatImageRepository>();
            services.AddScoped<BloodPressureRepository>();

            services.AddScoped<IUnitWork, UnitWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
