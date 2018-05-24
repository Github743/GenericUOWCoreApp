using AutoMapper;
using CoreApp.DataProvider;
using CoreApp.DataProvider.DataContext;
using CoreApp.DataService;
using CoreApp.DataService.Abstraction.Interfaces;
using CoreApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Mapper.Initialize(cfg => {
                cfg.AddProfile<DataModelMappingProfile>();
            });
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            InitializeServices(services);
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:dbConnection"]);
            });
            //services.AddTransient((_) => new DatabaseContext());
            services.AddMvc();
            services.AddSingleton(Configuration);
        }

        private void InitializeServices(IServiceCollection services)
        {
            services.AddScoped<EmployeeDataProvider>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
