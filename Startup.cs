using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; 
using SecondTestAPI.Models;  
using Microsoft.EntityFrameworkCore;  

namespace SecondTestAPI
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
            var server = Configuration["DBServer"] ?? "db-server";  
            var port = Configuration["DBPort"] ?? "1433";  
            var user = Configuration["DBUser"] ?? "sa";  
            var password = Configuration["DBPassword"]?? "Pwd12345!";  
            var database = Configuration["Database"] ?? "EmployeeDB";  
            var connection = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={password};";
            
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(connection));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            EmployeeDB.PrePopulation(app);

            
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
