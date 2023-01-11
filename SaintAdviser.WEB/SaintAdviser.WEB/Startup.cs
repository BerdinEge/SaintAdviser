using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaintAdviser.DAL.Repositories.Abstract.SADB;
using SaintAdviser.DAL.Repositories.Concrete.SADB;
using SaintAdviser.Data.SaintAdviserDB;
using SaintAdviser.Entity.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private DbContext _dbContext;
        private ServiceProvider _serviceProvider;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppGlobals.dbProviderType = Configuration.GetValue<enDbProviderType>("Provider");
            AppGlobals.ConnectionString = Configuration.GetConnectionString("Database");

            switch (AppGlobals.dbProviderType)
            {
                case enDbProviderType.MSSQL:
                    services.AddDbContext<SADBMSSQLContext>(ServiceLifetime.Transient, ServiceLifetime.Transient);
                    _serviceProvider = services.BuildServiceProvider();
                    _dbContext = _serviceProvider.GetService<SADBMSSQLContext>();
                    services.AddTransient<SADBBaseContext>(sp => sp.GetRequiredService<SADBMSSQLContext>());
                    break;
            }

            services.AddTransient<IRepContact, RepContact>();
            services.AddTransient<IRepEuropeServiceRequest, RepEuropeServiceRequest>();
            services.AddTransient<IRepLog, RepLog>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
