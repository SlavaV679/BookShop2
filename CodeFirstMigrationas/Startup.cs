using CodeFirstMigrationas.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstMigrationas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<EmployeeDbContext>(item => 
            //item.UseSqlServer(Configuration.GetValue<string>("Data:myconn:ConnectionString")));

            //services.AddDbContext<EmployeeDbContext>(item =>
            //    item.UseSqlServer(Configuration["ConnectionStrings:myconn"]));

            //services.AddDbContext<EmployeeDbContext>(item =>
            //item.UseSqlServer("server = (LocalDB)\\MSSQLLocalDB; database = EmployeeDB; Trusted_Connection = True;"));
            // todo
            // вот это работает, а если строку передавать через GetConnectionString
            //  выдает ошибку.
            //  Пробовал разные варианты что выше. В оригинале то что ниже
            //var t = Configuration.GetConnectionString("myconn");
            services.AddDbContext<EmployeeDbContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("myconn")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
